using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IUserRefreshTokenService
    {
        Task<Maybe<UserRefreshTokenDto>> ReadAsync(string refreshToken);
    }
}