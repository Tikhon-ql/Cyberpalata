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
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class ApiUserService : IApiUserService
    {
        private readonly IApiUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;

        public ApiUserService(IApiUserRepository userRepository, IConfiguration configuration/*,IMapper mapper*/)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            //_mapper = mapper;
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
        //? Нужна ли асинхронность
        public string GenerateToken(AuthenticateRequest request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, request.Email)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
