using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Interfaces.Room
{
    public interface IGameConsoleRoomRepository : IRepository<GameConsoleRoom>, IRoomRepository
    {
        List<GameConsole> GetGameConsoles(Guid id);
    }
}
