using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class ApiUserService : IApiUserService
    {
        private readonly IApiUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;

        public ApiUserService(IApiUserRepository userRepository, IConfiguration configuration, IUserRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _refreshTokenRepository = refreshTokenRepository;
        }

        /// <summary>
        /// Должен что-то возвращать для проверки добавился ли пользователь?
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> CreateAsync(AuthorizationRequest request)
        {
            //Добавить проверки
            await _userRepository.CreateAsync(ApiUserMapper.MapToApiUser(request));
            return Result.Ok();
        }

        public async Task<Result> ValidateUserAsync(AuthenticateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);
            if (user.Password == request.Password)
                return Result.Ok();
            return Result.Fail("Email or password is incorrect!!!");
        }

        public Token GenerateToken(AuthenticateRequest request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, request.Email)
            };
            var accessToken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: credentials);

            var refreshToken = GenerateRefreshToken();

            _refreshTokenRepository.CreateAsync(new UserRefreshToken {UserEmail = request.Email, RefreshToken = refreshToken});

            var token = new Token
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = refreshToken
            };

            return token;
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
    }
}
