using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class UserRefreshTokenService : IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenRepository _repository;
        private readonly IMapper _mapper;

        public UserRefreshTokenService(IUserRefreshTokenRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Maybe<UserRefreshTokenDto>> ReadAsync(string refreshToken)
        {
            var userRefreshToken = await _repository.ReadAsync(refreshToken);
            return _mapper.Map<Maybe<UserRefreshTokenDto>>(userRefreshToken);
        }

    }
}
