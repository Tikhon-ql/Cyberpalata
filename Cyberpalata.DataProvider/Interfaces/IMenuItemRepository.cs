using Cyberpalata.DataProvider.Models;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        List<Maybe<MenuItem>> GetByLoungeId(Guid roomId);
    }
}
