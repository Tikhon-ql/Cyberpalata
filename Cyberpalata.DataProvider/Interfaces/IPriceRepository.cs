using Cyberpalata.DataProvider.Models;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        Task<Maybe<List<Price>>> GetByRoomIdAsync(Guid roomId);
    }
}
