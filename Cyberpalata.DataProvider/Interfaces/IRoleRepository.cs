using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRoleRepository
    {
        Task<Maybe<Role>> ReadAsync(string roleName);
    }
}
