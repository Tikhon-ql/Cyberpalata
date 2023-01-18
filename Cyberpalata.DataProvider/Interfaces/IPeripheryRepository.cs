using Cyberpalata.DataProvider.Models.Peripheral;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPeripheryRepository : IRepository<Periphery>
    {
        Task<Maybe<List<Periphery>>> GetByGamingRoomId(Guid roomId);
    }
}
