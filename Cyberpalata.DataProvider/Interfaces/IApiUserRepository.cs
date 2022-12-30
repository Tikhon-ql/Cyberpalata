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
        Task CreateAsync(ApiUser user, string password);
        Task LoginAsync(string username, string password, bool isPersistent);
        Task LogoutAsync();
    }
}
