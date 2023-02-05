using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IUserRefreshTokenService
    {
        Task<Maybe<UserRefreshTokenDto>> ReadAsync(string refreshToken);
    }
}