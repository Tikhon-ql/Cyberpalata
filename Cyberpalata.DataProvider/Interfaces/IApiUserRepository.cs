using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IApiUserRepository : IRepository<ApiUser>
    {
        Task<Maybe<ApiUser>> ReadAsync(string email);
    }
}
