using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
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
        Task<Maybe<ApiUserDto>> ReadAsync(Guid id);
        Task<Result> ValidateUserAsync(AuthorizationRequest request);
    }
}
