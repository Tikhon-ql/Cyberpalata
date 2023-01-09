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
        private readonly IMapper _mapper;

        public ApiUserService(IApiUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Должен что-то возвращать для проверки добавился ли пользователь?
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> CreateAsync(AuthorizationRequest request)
        {
            //Добавить проверки
            return await _userRepository.CreateAsync(ApiUserMapper.MapToApiUser(request));
        }
    }
}
