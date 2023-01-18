using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IRoomService : IService<RoomDto>
    {
        Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber, RoomType type);
    }
}
