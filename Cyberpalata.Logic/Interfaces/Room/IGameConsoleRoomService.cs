﻿using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Room
{
    public interface IGameConsoleRoomService : IService<GameConsoleRoomDto>, IRoomService
    {
    }
}
