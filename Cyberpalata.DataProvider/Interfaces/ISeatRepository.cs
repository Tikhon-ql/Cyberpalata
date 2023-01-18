using Cyberpalata.DataProvider.Models;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<Maybe<List<Seat>>> GetByRoomIdAsync(Guid roomId);
    }
}
