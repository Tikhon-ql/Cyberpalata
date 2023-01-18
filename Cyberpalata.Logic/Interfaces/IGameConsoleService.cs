using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IGameConsoleService : IService<GameConsoleDto>
    {
        Task<Maybe<List<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId);
    }
}
