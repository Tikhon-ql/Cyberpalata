using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
