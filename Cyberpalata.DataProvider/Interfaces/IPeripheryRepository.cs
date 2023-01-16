using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPeripheryRepository : IRepository<Periphery>
    {
        Task<List<Maybe<Periphery>>> GetByGamingRoomId(Guid roomId);
    }
}
