using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IRoomService : IService<RoomDto>
    {
        Task<PagedList<Maybe<RoomDto>>> GetPagedListAsync(int pageNumber, RoomType type);
    }
}
