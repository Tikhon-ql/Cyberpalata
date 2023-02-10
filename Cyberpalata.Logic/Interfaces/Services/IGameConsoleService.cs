using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IGameConsoleService
    {
        Task<Maybe<List<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId);
    }
}
