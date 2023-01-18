using Cyberpalata.DataProvider.Models.Identity;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IApiUserRepository : IRepository<ApiUser>
    {
        Task<Maybe<ApiUser>> ReadAsync(string email);
    }
}
