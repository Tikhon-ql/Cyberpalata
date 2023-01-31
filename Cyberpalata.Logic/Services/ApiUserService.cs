using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity.User;

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

        public async Task<Result> CreateAsync(UserCreateRequest request)
        {
            var res = await ValidateUserAsync(request);

            if (res.IsFailure)
                return Result.Failure(res.Error);

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
            return Result.Success();
        }

        public async Task<Result> ValidateUserAsync(UserCreateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);

            if (user.HasValue)
                return Result.Failure("User is already exist!");

            return Result.Success();
        }

        public async Task<Maybe<ApiUserDto>> ReadAsync(Guid id)
        {
            var user = await _userRepository.ReadAsync(id);
            var result = _mapper.Map<ApiUserDto>(user.Value);
            return result;
        }

        public async Task UpdateUserAsync(UserUpdateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.UserId);
            if(request.Username != String.Empty)
                user.Value.Username = request.Username;
            if(request.Surname != String.Empty)
                user.Value.Surname = request.Surname;
            if(request.Email != String.Empty)
                user.Value.Email = request.Email;
            if(request.Phone != String.Empty)
                user.Value.Phone = request.Phone;
        }
    }
}
