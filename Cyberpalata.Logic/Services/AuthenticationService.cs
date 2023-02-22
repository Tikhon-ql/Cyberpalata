using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Request.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Cyberpalata.Logic.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHashGenerator _hashGenerator;

        public AuthenticationService(IUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository,IHashGenerator hashGenerator, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _mapper = mapper;
            _hashGenerator = hashGenerator;
        }

        public async Task<Result<UserDto>> ValidateUserAsync(AuthenticateViewModel viewModel)
        {
            var user = await _userRepository.ReadAsync(viewModel.Email);

            if (!user.HasValue)
                return Result.Failure<UserDto>("Email or password is incorrect!!!");
            if (!user.Value.IsActivated)
                return Result.Failure<UserDto>("Your account isn't activated");

            string requestHashedPassword = _hashGenerator.HashPassword($"{viewModel.Password}{user.Value.Salt}");

            if (user.Value.Password == requestHashedPassword)
                return Result.Success(_mapper.Map<UserDto>(user.Value));

            return Result.Failure<UserDto>("Email or password is incorrect!!!");
        }

        public async Task<TokenViewModel> GenerateTokenAsync(UserDto user)
        {
            var accessToken = GenerateAccessToken(user);

            var refreshToken = GenerateRefreshToken();

            var apiUser = (await _userRepository.ReadAsync(user.Email)).Value;

            int refreshTokenExpirationTimeInMinutes = int.Parse(_configuration["RefreshTokenSettings:ExpirationTimeMin"]);
            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser, Expiration = DateTime.Now.AddMinutes(refreshTokenExpirationTimeInMinutes), RefreshToken = refreshToken });

            return new TokenViewModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private async Task<bool> RefreshTokenIsExpired(UserRefreshToken refreshToken)
        {
            int beforeMinutes = int.Parse(_configuration["RefreshTokenSettings:TimeToCheckBeforeRefreshTokenExpiredMin"]);
            var isRefreshTokenExpired = DateTime.Now.AddMinutes(beforeMinutes) >= refreshToken.Expiration;
            return isRefreshTokenExpired;
        }

        //private bool ValidateAccessToken(string accessToken)
        //{
        //    var jwt = new JwtSecurityTokenHandler();
            
        //}

        private async Task<Result<UserRefreshToken>> ValidateRefreshToken(TokenViewModel viewModel)
        {
            var refreshToken = await _refreshTokenRepository.ReadAsync(viewModel.RefreshToken);
            if (!refreshToken.HasValue)
                return Result.Failure<UserRefreshToken>("Refresh token doesn't exist!");
            var userIdResult = GetIdClaim(viewModel.AccessToken, JwtRegisteredClaimNames.Sid);

            if (userIdResult.IsFailure)
                return Result.Failure<UserRefreshToken>(userIdResult.Error);

            if (userIdResult.Value != refreshToken.Value.User.Id)
                return Result.Failure<UserRefreshToken>("Your aren't owner of the refresh token");

            return Result.Success(refreshToken.Value);
        }

        private async Task<TokenViewModel> Refresh(UserRefreshToken refreshToken)
        {
            var isRefreshTokenExpired = await RefreshTokenIsExpired(refreshToken);
            if (isRefreshTokenExpired)
            {
                var token = await GenerateTokenAsync(_mapper.Map<UserDto>(refreshToken.User));
                return token;
            }
            else
            {
                var accessToken = GenerateAccessToken(_mapper.Map<UserDto>(refreshToken.User));
                return new TokenViewModel
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.RefreshToken
                };
            }
        }

        public async Task<Result<TokenViewModel>> RefreshTokenAsync(TokenViewModel viewModel)
        {
            var refreshTokenResult = await ValidateRefreshToken(viewModel);
            if (refreshTokenResult.IsFailure)
                return Result.Failure<TokenViewModel>(refreshTokenResult.Error);
            var refreshedToken = await Refresh(refreshTokenResult.Value);
            return Result.Success(refreshedToken);
        }


        private Result<Guid> GetIdClaim(string jwtToken ,string claimName)
        {
            var jwtSecurityTokenResult = ParseJwt(jwtToken);
            if (jwtSecurityTokenResult.IsFailure)
            {
                return Result.Failure<Guid>(jwtSecurityTokenResult.Error);
            }

            var jwtSecurityToken = jwtSecurityTokenResult.Value;

            var claim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == claimName);
            if (claim == null)
            {
                return Result.Failure<Guid>($"{claimName} claim missed.");
            }
            if(!Guid.TryParse(claim.Value, out Guid userId))
                return Result.Failure<Guid>($"Wrong userId value.");
            return Result.Success(userId);
        }

        private Result<JwtSecurityToken> ParseJwt(string jwtToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken;
                jwtSecurityToken = handler.ReadJwtToken(jwtToken);
                return Result.Success(jwtSecurityToken);
            }
            catch (Exception ex)
            {
                return Result.Failure<JwtSecurityToken>(ex.Message);
            }
        }

        private string GenerateAccessToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("role", user.Roles.Name)
            };

            //Add token settings to work with config.

            int accessTokenExpirationTimeInMinutes = int.Parse(_configuration["AccessTokenSettings:ExpirationTimeMin"]);

            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(accessTokenExpirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public async Task<Result> LogoutAsync(TokenViewModel tokenDto)
        {
            var userRefreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);
            if (userRefreshToken.HasNoValue)
                return Result.Failure("Refresh token isn't exist!");

            ///??? If i will get only id from Token probably i should rewrite GetClaim method to check owner id validation
            var userIdResult = GetIdClaim(tokenDto.AccessToken, JwtRegisteredClaimNames.Sid);
            if (userIdResult.IsFailure)
                return Result.Failure(userIdResult.Error);

            //var claimId = userIdClaim.Value;

            //if (!Guid.TryParse(claimId.Value, out Guid userId))
            //    return Result.Failure("Cannot parse id");

            //if (userId != userRefreshToken.Value.User.Id)
            //    return Result.Failure("Your aren't owner of the refresh token");

            if (userIdResult.Value != userRefreshToken.Value.User.Id)
                return Result.Failure("Your aren't owner of the refresh token");

            _refreshTokenRepository.Delete(userRefreshToken.Value);
            return Result.Success();
        }
    }
}