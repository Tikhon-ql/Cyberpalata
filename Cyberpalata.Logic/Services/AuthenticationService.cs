using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
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

        public async Task<Result<ApiUserDto>> ValidateUserAsync(Maybe<AuthenticateRequest> request)
        {
            if (!request.HasValue)
                return Result.Fail<ApiUserDto>("Invalid request!");

            var user = await _userRepository.ReadAsync(request.Value.Email);

            if (!user.HasValue)
                return Result.Fail<ApiUserDto>("Email or password is incorrect!!!");

            string requestHashedPassword = _hashGenerator.HashPassword($"{request.Value.Password}{user.Value.Salt}");

            if (user.Value.Password == requestHashedPassword)
                return Result.Ok(_mapper.Map<ApiUserDto>(user.Value));

            return Result.Fail<ApiUserDto>("Email or password is incorrect!!!");
        }

        public async Task<Maybe<TokenDto>> GenerateTokenAsync(ApiUserDto user)//ApiUser maybe????
        {
            var accessToken = GenerateAccessToken(user);

            if (!accessToken.HasValue)
                return Maybe<TokenDto>.Nothing;

            var refreshToken = GenerateRefreshToken();

            var apiUser = await _userRepository.ReadAsync(user.Email);

            if (!apiUser.HasValue)
                return Maybe<TokenDto>.Nothing;

            if (!int.TryParse(_configuration["RefreshTokenSettings:ExpirationTime"], out int refreshTokenExpirationTimeInMinutes))
                return Maybe<TokenDto>.Nothing;

            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser.Value, Expiration = DateTime.Now.AddMinutes(refreshTokenExpirationTimeInMinutes), RefreshToken = refreshToken });

            return new TokenDto
            {
                AccessToken = accessToken.Value,
                RefreshToken = refreshToken
            }.ToMaybe();//???????????????
        }

        public async Task<Result<TokenDto>> RefreshTokenAsync(Maybe<TokenDto> tokenDto)
        {

            if (!tokenDto.HasValue)
            {
                return Result.Fail<TokenDto>("Invalid request");
            }

            var claimIdResult = GetClaim(tokenDto.Value.AccessToken, JwtRegisteredClaimNames.Sid);
            if (claimIdResult.IsFailure)
                return Result.Fail<TokenDto>(claimIdResult.Error);

            var claimId = claimIdResult.Value;

            if (!Guid.TryParse(claimId.Value, out var userId))
            {
                return Result.Fail<TokenDto>("Cannot parse id");
            }

            Maybe<UserRefreshToken> refreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.Value.RefreshToken);

            if (!refreshToken.HasValue)
                return Result.Fail<TokenDto>("Refresh token doesn't exist!");

            if (userId != refreshToken.Value.User.Id)
            {
                return Result.Fail<TokenDto>("Your aren't owner of the refresh token");
            }

            if(!int.TryParse(_configuration["RefreshTokenSettings:TimeToCheckBeforeRefreshTokenExpired"],out int beforeMinutes))
            {
                return Result.Fail<TokenDto>("Wrong refresh token settings");
            }

            var isRefreshTokenExpired = DateTime.Now.AddMinutes(beforeMinutes) >= refreshToken.Value.Expiration;
            if (isRefreshTokenExpired)
            {
                var token = await GenerateTokenAsync(_mapper.Map<ApiUserDto>(refreshToken.Value.User));
                if (!token.HasValue)
                    return Result.Fail<TokenDto>("Something went wrong with token generation!");
                return Result.Ok(token.Value);
            }        
            else
            {
                var accessToken = GenerateAccessToken(_mapper.Map<ApiUserDto>(refreshToken.Value.User));
                if(!accessToken.HasValue)
                    return Result.Fail<TokenDto>("Something went wrong with token generation!");
                return Result.Ok(new TokenDto
                {
                    AccessToken = accessToken.Value,
                    RefreshToken = tokenDto.Value.RefreshToken
                });
            }
        }

        private Result<Claim> GetClaim(string jwtToken ,string claimName)
        {
            var jwtSecurityTokenResult = ParseJwt(jwtToken);
            if (jwtSecurityTokenResult.IsFailure)
            {
                return Result.Fail<Claim>(jwtSecurityTokenResult.Error);
            }

            var jwtSecurityToken = jwtSecurityTokenResult.Value;

            var claim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == claimName);
            if (claim == null)
            {
                return Result.Fail<Claim>($"{claimName} claim missed.");
            }
            return Result.Ok(claim);
        }

        private Result<JwtSecurityToken> ParseJwt(string jwtToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtSecurityToken;
                jwtSecurityToken = handler.ReadJwtToken(jwtToken);
                return Result.Ok(jwtSecurityToken);
            }
            catch (Exception ex)
            {
                return Result.Fail<JwtSecurityToken>(ex.Message);
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

            if (!int.TryParse(_configuration["AccessTokenSettings:ExpirationTime"], out int accessTokenExpirationTimeInMinutes))
                return Maybe<string>.Nothing;

            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(accessTokenExpirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(accessToken).ToMaybe();
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

        public async Task<Result> LogoutAsync(Maybe<TokenDto> tokenDto)
        {
            if (!tokenDto.HasValue)
                return Result.Fail("Invalid token request!");

            var userRefreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.Value.RefreshToken);

            if (!userRefreshToken.HasValue)
                return Result.Fail("Refresh token doesn't exist in database!");

            var claimIdResult = GetClaim(tokenDto.Value.AccessToken, JwtRegisteredClaimNames.Sid);
            if (claimIdResult.IsFailure)
                return Result.Fail(claimIdResult.Error);
            var claimId = claimIdResult.Value;            

            if (Guid.TryParse(claimId.Value, out Guid userId))
                return Result.Fail("Cannot parse id");

            if (userId != userRefreshToken.Value.User.Id)
                return Result.Fail("Your aren't owner of the refresh token");

            _refreshTokenRepository.Delete(userRefreshToken.Value);
            return Result.Ok();
        }
    }
}
