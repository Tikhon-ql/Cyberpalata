using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Peripheral;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPeripheryService
    {
        Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId);
    }
}
