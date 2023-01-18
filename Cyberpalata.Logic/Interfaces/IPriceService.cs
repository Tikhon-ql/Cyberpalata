using Cyberpalata.Logic.Models;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPriceService : IService<PriceDto>
    {
        Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId);
    }
}
