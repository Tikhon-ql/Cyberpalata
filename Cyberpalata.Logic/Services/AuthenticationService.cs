using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.Logic.Models.Identity.User;
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
        private readonly IApiUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHashGenerator _hashGenerator;

        public AuthenticationService(IApiUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository,IHashGenerator hashGenerator, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
            _mapper = mapper;
            _hashGenerator = hashGenerator;
        }

        public async Task<Result<ApiUserDto>> ValidateUserAsync(AuthenticateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);

            if (!user.HasValue)
                return Result.Failure<ApiUserDto>("Email or password is incorrect!!!");
            if (!user.Value.IsActivate)
                return Result.Failure<ApiUserDto>("Your account isn't activated");

            string requestHashedPassword = _hashGenerator.HashPassword($"{request.Password}{user.Value.Salt}");

            if (user.Value.Password == requestHashedPassword)
                return Result.Success(_mapper.Map<ApiUserDto>(user.Value));

            return Result.Failure<ApiUserDto>("Email or password is incorrect!!!");
        }

        public async Task<Maybe<TokenDto>> GenerateTokenAsync(ApiUserDto user)
        {
            var accessToken = GenerateAccessToken(user);

            if (!accessToken.HasValue)
                return Maybe.None;

            var refreshToken = GenerateRefreshToken();

            var apiUser = await _userRepository.ReadAsync(user.Email);

            if (!apiUser.HasValue)
                return Maybe.None;

            if (!int.TryParse(_configuration["RefreshTokenSettings:ExpirationTimeMin"], out int refreshTokenExpirationTimeInMinutes))
                return Maybe.None;

            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser.Value, Expiration = DateTime.Now.AddMinutes(refreshTokenExpirationTimeInMinutes), RefreshToken = refreshToken });

            return new TokenDto
            {
                AccessToken = accessToken.Value,
                RefreshToken = refreshToken
            };//???????????????
        }
        //Maybe = valid null
        public async Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto)
        {
            var claimIdResult = GetClaim(tokenDto.AccessToken, JwtRegisteredClaimNames.Sid);
            if (claimIdResult.IsFailure)
                return Result.Failure<TokenDto>(claimIdResult.Error);

            var claimId = claimIdResult.Value;

            if (!Guid.TryParse(claimId.Value, out var userId))
            {
                return Result.Failure<TokenDto>("Cannot parse id");
            }

            Maybe<UserRefreshToken> refreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);

            if (!refreshToken.HasValue)
                return Result.Failure<TokenDto>("Refresh token doesn't exist!");

            if (userId != refreshToken.Value.User.Id)
            {
                return Result.Failure<TokenDto>("Your aren't owner of the refresh token");
            }

            if(!int.TryParse(_configuration["RefreshTokenSettings:TimeToCheckBeforeRefreshTokenExpiredMin"],out int beforeMinutes))//Parse
            {
                return Result.Failure<TokenDto>("Wrong refresh token settings");
            }

            var isRefreshTokenExpired = DateTime.Now.AddMinutes(beforeMinutes) >= refreshToken.Value.Expiration;
            if (isRefreshTokenExpired)
            {
                var token = await GenerateTokenAsync(_mapper.Map<ApiUserDto>(refreshToken.Value.User));
                if (!token.HasValue)
                    return Result.Failure<TokenDto>("Something went wrong with token generation!");
                return Result.Success(token.Value);
            }        
            else
            {
                var accessToken = GenerateAccessToken(_mapper.Map<ApiUserDto>(refreshToken.Value.User));
                if(!accessToken.HasValue)
                    return Result.Failure<TokenDto>("Something went wrong with token generation!");
                return Result.Success(new TokenDto
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



        private Maybe<string> GenerateAccessToken(ApiUserDto user)
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
                expires: DateTime.Now.AddMinutes(accessTokenExpirationTimeInMinutes),
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

        public async Task<Result> LogoutAsync(TokenDto tokenDto)
        {
            var userRefreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);
            //add own error class
            if (!userRefreshToken.HasValue)
                return Result.Failure("");

            var claimIdResult = GetClaim(tokenDto.AccessToken, JwtRegisteredClaimNames.Sid);
            if (claimIdResult.IsFailure)
                return Result.Failure(claimIdResult.Error);
            var claimId = claimIdResult.Value;

            if (!Guid.TryParse(claimId.Value, out Guid userId))
                return Result.Failure("Cannot parse id");

            if (userId != userRefreshToken.Value.User.Id)
                return Result.Failure("Your aren't owner of the refresh token");

            _refreshTokenRepository.Delete(userRefreshToken.Value);
            return Result.Success();
        }
    }
}
