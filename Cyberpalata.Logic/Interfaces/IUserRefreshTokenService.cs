using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IUserRefreshTokenService
    {
        //Task CreateAsync(UserRefreshTokenDto entity);
        Task<UserRefreshTokenDto> ReadAsync(Guid userId);
        Task DeleteAsync(string refreshToken);
    }
}
