using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPcRepository : IRepository<Pc>
    {
        List<Pc> GetByGamingRoomId(Guid roomId);
    }
}
