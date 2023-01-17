using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPcService : IService<PcDto>
    {
        Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId);
    }
}
