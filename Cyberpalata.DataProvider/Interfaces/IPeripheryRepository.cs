using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Peripheral;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPeripheryRepository : IRepository<Periphery>
    {
        Task<Maybe<List<Periphery>>> GetByGamingRoomId(Guid roomId);
    }
}
