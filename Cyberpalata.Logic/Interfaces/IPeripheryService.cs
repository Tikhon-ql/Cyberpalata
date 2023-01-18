using Cyberpalata.Logic.Models.Peripheral;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPeripheryService : IService<PeripheryDto>
    {
        Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId);
    }
}
