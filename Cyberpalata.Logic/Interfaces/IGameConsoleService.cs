﻿using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IGameConsoleService : IService<GameConsoleDto>
    {
        Task<List<Maybe<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId);
    }
}