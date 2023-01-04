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
        Task CreateAsync(AuthorizationRequest request);
        Task<bool> ValidateUserAsync(string email, string password);
        Task<string> GenerateTokenAsync(string email, string password);
    }
}
