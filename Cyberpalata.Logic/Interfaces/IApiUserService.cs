using Cyberpalata.Common;
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
        Task<Result> CreateAsync(AuthorizationRequest request);
        Task<Result> ValidateUserAsync(AuthenticateRequest request);
        Token GenerateToken(AuthenticateRequest request);
    }
}
