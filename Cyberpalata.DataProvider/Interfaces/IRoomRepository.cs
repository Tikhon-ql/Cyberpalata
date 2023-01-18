using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type);
    }
}
