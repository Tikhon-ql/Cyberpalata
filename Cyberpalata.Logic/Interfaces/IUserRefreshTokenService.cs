using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IUserRefreshTokenService
    {
        Task<UserRefreshTokenDto> ReadAsync(string refreshToken);
    }
}