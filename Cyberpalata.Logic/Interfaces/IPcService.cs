using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPcService : IService<PcDto>
    {
        Task<PcDto> GetByGamingRoomId(Guid roomId);
    }
}
