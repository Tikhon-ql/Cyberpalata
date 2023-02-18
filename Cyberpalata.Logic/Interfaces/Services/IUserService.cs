using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel.Request.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<Guid>> CreateAsync(UserCreateViewModel request);
        Task<Maybe<UserDto>> ReadAsync(Guid id);
        Task<Result> ValidateUserAsync(UserCreateViewModel request);
        Task UpdateUserAsync(UserUpdateRequest request);
        Task PasswordRecoveryAsync([EmailAddress] string email);
        Task<Result> ResetPasswordAsync(PasswordResetViewModel request);
        Task<Result<int>> SendCodeToMailAsync(EmailConfirmViewModel viewModel);
        Task<Result> DeleteAsync(string email);
        Task<Result> ActivateUser(string email);
    }
}
