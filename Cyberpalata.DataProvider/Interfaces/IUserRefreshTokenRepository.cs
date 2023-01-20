using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IUserRefreshTokenRepository
    {
        Task CreateAsync(UserRefreshToken entity);
        Task<Maybe<UserRefreshToken>> ReadAsync(string refreshToken);
        void Delete(UserRefreshToken refreshToken);
        Task<Maybe<ApiUser>> GetUserByRefreshToken(string refreshToken);
    }
}
