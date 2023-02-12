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

            //A.K.: really password is incorrect?)
            if (!user.HasValue)
                return Result.Failure<UserDto>("Email or password is incorrect!!!");
            if (!user.Value.IsActivate)
                return Result.Failure<UserDto>("Your account isn't activated");

            string requestHashedPassword = _hashGenerator.HashPassword($"{viewModel.Password}{user.Value.Salt}");

            if (user.Value.Password == requestHashedPassword)
                return Result.Success(_mapper.Map<UserDto>(user.Value));

            //A.K.: really email is invalid here?
            return Result.Failure<UserDto>("Email or password is incorrect!!!");
        }

        public async Task<Maybe<TokenViewModel>> GenerateTokenAsync(UserDto user)
        {
            var accessToken = GenerateAccessToken(user);

            if (!accessToken.HasValue)
                return Maybe.None;

            var refreshToken = GenerateRefreshToken();

            var apiUser = await _userRepository.ReadAsync(user.Email);

            //A.K.:are you sure it is allowed user to be .None here? I mean it is not an exception?
            //Its exception because we validatie user before???
            //???
            //if (!apiUser.HasValue)
            //    return Maybe.None;

            int refreshTokenExpirationTimeInMinutes = int.Parse(_configuration["RefreshTokenSettings:ExpirationTimeMin"]);
            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser.Value, Expiration = DateTime.Now.AddMinutes(refreshTokenExpirationTimeInMinutes), RefreshToken = refreshToken });

            return new TokenViewModel
            {
                AccessToken = accessToken.Value,
                RefreshToken = refreshToken
            };
        }
        //A.K.: methods more than 20 lines usually can be simply split to multiply which increase readability
        public async Task<Result<TokenViewModel>> RefreshTokenAsync(TokenViewModel tokenDto)
        {
            Maybe<UserRefreshToken> refreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);
            if (!refreshToken.HasValue)
                return Result.Failure<TokenViewModel>("Refresh token doesn't exist!");

            var claimIdResult = GetClaim(tokenDto.AccessToken, JwtRegisteredClaimNames.Sid);
            if (claimIdResult.IsFailure)
                return Result.Failure<TokenViewModel>(claimIdResult.Error);
            var claimId = claimIdResult.Value;
            var userId = Guid.Parse(claimId.Value);

            //if (userId != refreshToken.Value.User.Id)
            //{
            //    return Result.Failure<TokenViewModel>("Your aren't owner of the refresh token");
            //}

            OwnerIdClaimValidation(claimId, refreshToken.Value.User.Id);
            int beforeMinutes = int.Parse(_configuration["RefreshTokenSettings:TimeToCheckBeforeRefreshTokenExpiredMin"]);
            var isRefreshTokenExpired = DateTime.Now.AddMinutes(beforeMinutes) >= refreshToken.Value.Expiration;
            if (isRefreshTokenExpired)
            {
                var token = await GenerateTokenAsync(_mapper.Map<UserDto>(refreshToken.Value.User));
                if (!token.HasValue)
                    return Result.Failure<TokenViewModel>("Something went wrong with token generation!");
                return Result.Success(token.Value);
            }        
            else
            {
                var accessToken = GenerateAccessToken(_mapper.Map<UserDto>(refreshToken.Value.User));
                if(!accessToken.HasValue)
                    return Result.Failure<TokenViewModel>("Something went wrong with token generation!");
                return Result.Success(new TokenViewModel
                {
                    AccessToken = accessToken.Value,
                    RefreshToken = tokenDto.RefreshToken
                });
            }
        }

        private Result<Claim> GetClaim(string jwtToken ,string claimName)
        {
            var jwtSecurityTokenResult = ParseJwt(jwtToken);
            if (jwtSecurityTokenResult.IsFailure)
            {
                return Result.Failure<Claim>(jwtSecurityTokenResult.Error);
            }

            var jwtSecurityToken = jwtSecurityTokenResult.Value;

            var claim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == claimName);
            if (claim == null)
            {
                return Result.Failure<Claim>($"{claimName} claim missed.");
            }
            return Result.Success(claim);
        }

        private Result OwnerIdClaimValidation(Claim claimId, Guid rightOwnerId)
        {
            //??? It's exception?
            if (!Guid.TryParse(claimId.Value, out Guid userId))
                return Result.Failure("Cannot parse id");
            if (userId != rightOwnerId)
                return Result.Failure("Your aren't owner of the refresh token");
            return Result.Success();
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



        private Maybe<string> GenerateAccessToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            if (!int.TryParse(_configuration["AccessTokenSettings:ExpirationTimeMin"], out int accessTokenExpirationTimeInMinutes))
                return Maybe.None;

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
            var userIdClaim = GetClaim(tokenDto.AccessToken, JwtRegisteredClaimNames.Sid);
            if (userIdClaim.IsFailure)
                return Result.Failure(userIdClaim.Error);

            var claimId = userIdClaim.Value;

            //if (!Guid.TryParse(claimId.Value, out Guid userId))
            //    return Result.Failure("Cannot parse id");

            //if (userId != userRefreshToken.Value.User.Id)
            //    return Result.Failure("Your aren't owner of the refresh token");

            OwnerIdClaimValidation(claimId, userRefreshToken.Value.User.Id);

            _refreshTokenRepository.Delete(userRefreshToken.Value);
            return Result.Success();
        }
    }
}
