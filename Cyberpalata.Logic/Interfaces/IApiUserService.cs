using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity.User;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IApiUserService
    {
        Task<Result> CreateAsync(UserCreateRequest request);
        Task<Maybe<ApiUserDto>> ReadAsync(Guid id);
        Task<Result> ValidateUserAsync(UserCreateRequest request);
        Task UpdateUserAsync(UserUpdateRequest request);
    }
}
