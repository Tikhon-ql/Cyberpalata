using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPriceService : IService<PriceDto>
    {
        Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId);
    }
}
