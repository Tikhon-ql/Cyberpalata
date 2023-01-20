using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Peripheral;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPeripheryRepository : IRepository<Periphery>
    {
        Task<Maybe<List<Periphery>>> GetByGamingRoomId(Guid roomId);
    }
}
