using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ISeatService : IService<SeatDto>
    {
        Task CreateRangeAsync(List<SeatDto> seats);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomId(Guid roomId);
    }
}
