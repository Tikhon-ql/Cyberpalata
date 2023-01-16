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
        private readonly IHashGenerator _hashGenerator;

        public ApiUserService(IApiUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository, IMapper mapper, IHashGenerator hashGenerator)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _hashGenerator = hashGenerator;
        }

        public async Task<Result> CreateAsync(AuthorizationRequest request)
        {
            var res = await ValidateUserAsync(request);
            if (res.IsFailure)
                return Result.Fail(res.Error);

            var newUser = new ApiUser
            {
                Email = request.Email,
                Username = request.Username,
                Surname = request.Surname,
                Phone = request.Phone,
                Salt = _hashGenerator.GenerateSalt()
            };

            var password = $"{request.Password}{newUser.Salt}";

            newUser.Password = _hashGenerator.HashPassword(password);

            await _userRepository.CreateAsync(newUser);
            return Result.Ok();
        }

        public async Task<Result> ValidateUserAsync(AuthorizationRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);
            if (user.Value != null)
                return Result.Fail("User is already exist!");
            return Result.Ok();
        }

        public async Task<Maybe<ApiUserDto>> ReadAsync(Guid id)
        {
            var user = _mapper.Map<ApiUserDto>((await _userRepository.ReadAsync(id)).Value);
            return user;
        }
    }
}
