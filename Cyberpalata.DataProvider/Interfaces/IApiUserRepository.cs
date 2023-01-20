using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IApiUserRepository : IRepository<ApiUser>
    {
        Task<Maybe<ApiUser>> ReadAsync(string email);
    }
}
