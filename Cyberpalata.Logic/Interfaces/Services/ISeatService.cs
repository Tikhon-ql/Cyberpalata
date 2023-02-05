using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Seats;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ISeatService : IService<SeatDto>
    {
        Task CreateRangeAsync(List<SeatDto> seats);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomIdAsync(Guid roomId);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomInRangeIdAsync(SeatsGettingRequest request);
    }
}
