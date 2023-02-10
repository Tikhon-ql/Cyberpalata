using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity.User;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IApiUserService
    {
        Task<Result> CreateAsync(UserCreateRequest request);
        Task<Maybe<ApiUserDto>> ReadAsync(Guid id);
        Task<Result> ValidateUserAsync(UserCreateRequest request);
        Task UpdateUserAsync(UserUpdateRequest request);
        Task PasswordRecoveryAsync([EmailAddress] string email);
        Task<Result> ResetPasswordAsync(PasswordResetRequest request);
        int SendCodeToMail(string email);
        Task<Result> DeleteAsync(string email);
        Task<Result> ActivateUser(string email);
    }
}
