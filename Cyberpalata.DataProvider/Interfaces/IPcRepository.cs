using Cyberpalata.DataProvider.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPcRepository : IRepository<Pc>
    {
        Task<Maybe<Pc>> GetByGamingRoomId(Guid roomId);
    }
}   
