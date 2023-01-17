using AutoMapper;
using Azure.Core;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                return Result.Fail<ApiUserDto>("Email or password is incorrect!!!");

            string requestHashedPassword = _hashGenerator.HashPassword($"{request.Password}{user.Value.Salt}");

            if (user.Value.Password == requestHashedPassword)
                return Result.Ok(_mapper.Map<ApiUserDto>(user.Value));

            return Result.Fail<ApiUserDto>("Email or password is incorrect!!!");
        }

        public async Task<Maybe<TokenDto>> GenerateTokenAsync(ApiUserDto user)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            var apiUser = await _userRepository.ReadAsync(user.Email);

            if (!apiUser.HasValue)
                return Maybe<TokenDto>.Nothing;

            await _refreshTokenRepository.CreateAsync(new UserRefreshToken { User = apiUser.Value, Expiration = DateTime.Now.AddDays(2), RefreshToken = refreshToken });

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            }.ToMaybe();
        }

        public async Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken;

            try
            {
                jwtSecurityToken = handler.ReadJwtToken(tokenDto.AccessToken);
            }
            catch(Exception ex)
            {
                return Result.Fail<TokenDto>(ex.Message);
            }

            var claimId = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid);

            if (claimId == null)
                return Result.Fail<TokenDto>("Id claim missed.");

            if (!Guid.TryParse(claimId.Value, out var userId))
            {
                return Result.Fail<TokenDto>("Cannot parse id");
            }

            Maybe<UserRefreshToken> refreshToken = await _refreshTokenRepository.ReadAsync(tokenDto.RefreshToken);

            if (!refreshToken.HasValue)
                return Result.Fail<TokenDto>("Refresh token doesn't exist!");

            if (userId != refreshToken.Value.User.Id)
            {
                return Result.Fail<TokenDto>("Your aren't owner of the refresh token");
            }

            var isRefreshTokenExpired = DateTime.Now.AddMinutes(30) >= refreshToken.Value.Expiration;
            if (isRefreshTokenExpired)
                return Result.Ok((await GenerateTokenAsync(_mapper.Map<ApiUserDto>(refreshToken.Value.User))).Value);
            else
            {
                return Result.Ok(new TokenDto
                {
                    AccessToken = GenerateAccessToken(_mapper.Map<ApiUserDto>(refreshToken.Value.User)),
                    RefreshToken = tokenDto.RefreshToken
                });
            }
        }


        private string GenerateAccessToken(ApiUserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name,user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
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

            if (!userRefreshToken.HasValue)
                return Result.Fail("Refresh token doesn't exist in database!");

            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = handler.ReadJwtToken(tokenDto.AccessToken);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
       
            var claimId = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid);

            if (claimId == null)
                return Result.Fail("Id claim missed.");

            if (Guid.TryParse(claimId.Value, out Guid userId))
                return Result.Fail("Cannot parse id");


            if (userId != userRefreshToken.Value.User.Id)
                return Result.Fail("Your aren't owner of the refresh token");

            _refreshTokenRepository.Delete(userRefreshToken.Value);
            return Result.Ok();
        }
    }
}
