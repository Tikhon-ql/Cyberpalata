using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity.User;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Services
{
    internal class ApiUserService : IApiUserService
    {
        private readonly IApiUserRepository _userRepository;
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHashGenerator _hashGenerator;
        private readonly IMailService _mailService;

        public ApiUserService(IApiUserRepository userRepository, IUserRefreshTokenRepository refreshTokenRepository, 
            IMapper mapper, IHashGenerator hashGenerator,IMailService mailService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
            _configuration = configuration;
            _hashGenerator = hashGenerator;
            _mailService = mailService;
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

            if (user.HasValue && user.Value.IsActivate)
                return Result.Failure("User is already exist!");

            return Result.Success();
        }

        public async Task<Maybe<ApiUserDto>> ReadAsync(Guid id)
        {
            var user = await _userRepository.ReadAsync(id);
            if (!user.Value.IsActivate)
                return Maybe.None;
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

        public async Task PasswordRecoveryAsync([EmailAddress]string email)
        {
            string bodyHtml = @$"<html>
                                    <div>
                                        <a href='http://localhost:3000/passwordReset/{email}' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>
                                    </div>
                                </html>";
            _mailService.SendMail(email,"Password recovering", bodyHtml);
        }

        public async Task<Result> ResetPasswordAsync(PasswordResetRequest request)
        {
            var user = await _userRepository.ReadAsync(request.Email);
            if (user.HasNoValue)
                return Result.Failure($"User with email:{request.Email} doesn't exist");
            user.Value.Salt = _hashGenerator.GenerateSalt();
            user.Value.Password = _hashGenerator.HashPassword($"{request.Password}{user.Value.Salt}");
            return Result.Success();
        }

        public int SendCodeToMail([EmailAddress] string email)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int code = rnd.Next(100000,9999999);
            string bodyHtml = @$"<html>
                                <div>
                                    <h1>Your verification code:</h1>
                                    <div><b>{code}</b></div>
                                </div>
                            </html>";
            _mailService.SendMail(email, "Email verification", bodyHtml);
            return code;
        }

        public async Task<Result> DeleteAsync([EmailAddress] string email)
        {
            var user = await _userRepository.ReadAsync(email);
            if (user.HasNoValue)
                return Result.Failure($"User with email: {email} doesn't exist");
            _userRepository.Delete(user.Value);
            return Result.Success();
        }

        public async Task<Result> ActivateUser(string email)
        {
            var user = await _userRepository.ReadAsync(email);
            if (user.HasNoValue)
                return Result.Failure($"User with email: {email} doesn't exist");
            user.Value.IsActivate = true;
            return Result.Success();
        }
    }
}
