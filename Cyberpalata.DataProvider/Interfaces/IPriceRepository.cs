﻿using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Maybe<List<Price>>> GetByRoomIdAsync(Guid roomId);
    }
}
