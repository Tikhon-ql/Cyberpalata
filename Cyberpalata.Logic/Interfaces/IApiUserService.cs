using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IApiUserService
    {
        Task<Result> CreateAsync(Maybe<AuthorizationRequest> request);
        Task<Maybe<ApiUserDto>> ReadAsync(Guid id);
        Task<Result> ValidateUserAsync(AuthorizationRequest request);
    }
}
