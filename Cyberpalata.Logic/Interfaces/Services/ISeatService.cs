using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Seats;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ISeatService
    {
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomIdAsync(Guid roomId);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomInRangeIdAsync(SeatsGettingRequest request);
    }
}
