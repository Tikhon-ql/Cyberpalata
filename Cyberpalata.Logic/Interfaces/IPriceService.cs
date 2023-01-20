using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPriceService : IService<PriceDto>
    {
        Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId);
    }
}
