using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;

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
