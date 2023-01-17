using Cyberpalata.Common;
using Cyberpalata.Logic.Models;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPriceService : IService<PriceDto>
    {
        Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId);
    }
}
