using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<Maybe<List<Booking>>> GetActualBookingsByRoomId(Guid roomId);
    }
}
