using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Maybe<User>> ReadAsync(string email);
    }
}
