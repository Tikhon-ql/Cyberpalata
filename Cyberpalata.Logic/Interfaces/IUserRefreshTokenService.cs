using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IUserRefreshTokenService
    {
        Task<Maybe<UserRefreshTokenDto>> ReadAsync(string refreshToken);
    }
}