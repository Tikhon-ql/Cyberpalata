using Cyberpalata.DataProvider.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IGameConsoleRepository : IRepository<GameConsole>
    {
        Task<Maybe<List<GameConsole>>> GetByGameConsoleRoomIdAsync(Guid roomId);
    }
}
