using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Interfaces.Room
{
    public interface IGamingRoomRepository : IRepository<GamingRoom>, IRoomRepository
    {
        List<Periphery> GetPeripheries(Guid id);
        List<Pc> GetPcs(Guid id);
    }
}
