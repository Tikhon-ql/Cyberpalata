using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRoleRepository
    {
        Task<Maybe<Role>> ReadAsync(string roleName);
    }
}
