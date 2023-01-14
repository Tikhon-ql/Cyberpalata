﻿using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPeripheryService : IService<PeripheryDto>
    {
        Task<List<PeripheryDto>> GetByGamingRoomId(Guid roomId);
    }
}
