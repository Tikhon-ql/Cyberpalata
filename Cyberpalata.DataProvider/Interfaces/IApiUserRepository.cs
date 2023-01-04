using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IApiUserRepository
    {
        Task CreateAsync(ApiUser entity);
        Task<ApiUser> ReadAsync(string email);
        Task<PagedList<ApiUser>> GetPageListAsync(int pageNumber);
    }
}
