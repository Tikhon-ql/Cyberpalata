using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        //List<Maybe<MenuItem>> GetByLoungeId(Guid roomId);
    }
}
