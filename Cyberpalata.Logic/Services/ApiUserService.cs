using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;

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

        public async Task<Result> CreateAsync(Maybe<AuthorizationRequest> request)
        {
            if (!request.HasValue)
                return Result.Failure("Invalid request!");

            var res = await ValidateUserAsync(request.Value);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            var newUser = new ApiUser
            {
                Email = request.Value.Email,
                Username = request.Value.Username,
                Surname = request.Value.Surname,
                Phone = request.Value.Phone,
                Salt = _hashGenerator.GenerateSalt()
            };

            var password = $"{request.Value.Password}{newUser.Salt}";

            newUser.Password = _hashGenerator.HashPassword(password);

            await _userRepository.CreateAsync(newUser);
            return Result.Success();
        }

        public async Task<Result> ValidateUserAsync(AuthorizationRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);

            if (user.HasValue)
                return Result.Failure("User is already exist!");

            return Result.Success();
        }

        public async Task<Maybe<ApiUserDto>> ReadAsync(Guid id)
        {
            var user = _mapper.Map<Maybe<ApiUserDto>>(await _userRepository.ReadAsync(id));
            return user;
        }
    }
}
