using AutoMapper;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class ApiUserService : IApiUserService
    {
        private readonly IApiUserRepository _userRepository;
        //private readonly IMapper _mapper;

        public ApiUserService(IApiUserRepository userRepository/*, IMapper mapper*/)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
        }

        public async Task CreateAsync(ApiUserDto user, string password)
        {
            await _userRepository.CreateAsync(ApiUserMapper.MapFromDto(user), password);
        }

        public async Task LoginAsync(string username, string password, bool isPersistent)
        {
            await _userRepository.LoginAsync(username, password, isPersistent);
        }

        public async Task LogoutAsync()
        {
            await _userRepository.LogoutAsync();
        }
    }
}
