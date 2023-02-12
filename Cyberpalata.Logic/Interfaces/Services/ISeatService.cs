using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.ViewModel.Request.Seats;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ISeatService
    {
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomIdAsync(Guid roomId);
        Task<Maybe<List<SeatDto>>> GetSeatsByRoomInRangeIdAsync(SeatsGettingViewModel request);
    }
}
