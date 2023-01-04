using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IGameConsoleRepository : IRepository<GameConsole>
    {
        //TODO: add pagination
        Task<List<GameConsole>> GetByGameConsoleRoomIdAsync(Guid roomId);
    }
}
