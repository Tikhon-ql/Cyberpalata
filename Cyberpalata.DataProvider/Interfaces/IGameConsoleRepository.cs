using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IGameConsoleRepository : IRepository<GameConsole>
    {
        Task<Maybe<List<GameConsole>>> GetByGameConsoleRoomIdAsync(Guid roomId);
    }
}
