using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IApiUserService
    {
        Task CreateAsync(ApiUserDto user, string password);
        Task LoginAsync(string username, string password, bool isPersistent);
        Task LogoutAsync();
    }
}
