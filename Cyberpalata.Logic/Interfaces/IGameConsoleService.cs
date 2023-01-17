using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IGameConsoleService : IService<GameConsoleDto>
    {
        Task<Maybe<List<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId);
    }
}
