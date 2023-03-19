using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel.Request.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHashGenerator _hashGenerator;
        private readonly IMailService _mailService;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository,IMapper mapper,
                            IHashGenerator hashGenerator,IMailService mailService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _hashGenerator = hashGenerator;
            _mailService = mailService;
            _roleRepository = roleRepository;
        }

        public async Task<Result<Guid>> CreateAsync(UserCreateViewModel request)
        {
            var res = await ValidateUserAsync(request);

            if (res.IsFailure)
                return Result.Failure<Guid>(res.Error);

            var newUser = new User
            {
                Email = request.Email,
                Username = request.Username,
                Surname = request.Surname,
                Phone = request.Phone,
                Salt = _hashGenerator.GenerateSalt(),
                Role = new Role()
            };

            var password = $"{request.Password}{newUser.Salt}";

            newUser.Password = _hashGenerator.HashPassword(password);
            await AddUserToRole(newUser, "User");
            var userId = await _userRepository.CreateAsync(newUser);
            return Result.Success(userId);
        }

        public async Task<Result> ValidateUserAsync(UserCreateViewModel request)
        {
            var validator = new UserCreateViewModelValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                string error = "";
                foreach (var item in result.Errors)
                    error += item + "\n";
                return Result.Failure(error);
            }
            var user = await _userRepository.ReadAsync(request.Email);

            if (user.HasValue && user.Value.IsActivated)
                return Result.Failure("User is already exist!");

            return Result.Success();
        }

        public async Task<Maybe<UserDto>> ReadAsync(Guid id)
        {
            var user = await _userRepository.ReadAsync(id);
            if (!user.Value.IsActivated)
                return Maybe.None;
            var result = _mapper.Map<UserDto>(user.Value);
            return result;
        }

        public async Task UpdateUserAsync(UserUpdateRequest request)
        {
            var user = await _userRepository.ReadAsync(request.UserId);
            user.Value.Username = request.Username;
            user.Value.Surname = request.Surname;
            user.Value.Phone = request.Phone;
        }


        //TODO: GET HTML FROM DB
        public async Task PasswordRecoveryAsync([EmailAddress]string email)
        {
            //A.K.:url is hardcoded - how it will be changed for PROD env?
            //use stringbuilder or, better some library to create html
            //string bodyHtml = @$"<html>
            //                        <div>
            //                            <a href='http://localhost:3000/passwordReset/{email}' class='btn btn-outline-dark btn-sm text-white w-50 m-1'>Reset password</a>
            //                        </div>
            //                    </html>";
            //_mailService.SendMail(email,"Password recovering", bodyHtml);
            _mailService.SendPasswordResetEmail(email);
        }

        public async Task<Result> ResetPasswordAsync(PasswordResetViewModel request)
        {
            var user = await _userRepository.ReadAsync(request.Email);
            if (user.HasNoValue)
                return Result.Failure($"User with email:{request.Email} doesn't exist");
            user.Value.Salt = _hashGenerator.GenerateSalt();
            user.Value.Password = _hashGenerator.HashPassword($"{request.Password}{user.Value.Salt}");
            return Result.Success();
        }

        //TODO: GET HTML FROM DB
        public async Task<Result<int>> SendCodeToMailAsync(EmailConfirmViewModel viewModel)
        {
            var user = await _userRepository.ReadAsync(viewModel.UserId);
            if (user.HasNoValue)
                return Result.Failure<int>("User not found!");
            var rnd = new Random(DateTime.Now.Millisecond);
            int code = rnd.Next(100000,9999999);
            //A.K.:same about html
            //string bodyHtml = @$"<html>
            //                    <div>
            //                        <h1>Your verification code:</h1>
            //                        <div><b>{code}</b></div>
            //                    </div>
            //                </html>";
            //_mailService.SendMail(email, "Email verification", bodyHtml);
            _mailService.SendVerificationCodeToMail(viewModel.Email, code);
            return code;
        }

        public async Task<Result> DeleteAsync(string email)
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
            user.Value.IsActivated = true;
            return Result.Success();
        }

        private async Task<Result> AddUserToRole(User user, string roleName)
        {
            var role = await _roleRepository.ReadAsync(roleName);
            if (role.HasNoValue)
                return Result.Failure("Role not found");
            user.Role = role.Value;
            return Result.Success();
        }
    }
}
