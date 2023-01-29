using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces
{
    public interface ISeatService : IService<SeatDto>
    {
        Task CreateRangeAsync(List<SeatDto> seats);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomId(Guid roomId);
    }
}
