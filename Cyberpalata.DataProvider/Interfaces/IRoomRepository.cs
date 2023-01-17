﻿using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type);
    }
}
