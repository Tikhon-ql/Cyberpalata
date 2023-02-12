using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        //Task<PagedList<Booking>> GetPagedListAsync(int pageNumber, Guid userId);
        Task<Maybe<List<Booking>>> GetActualBookingsByRoomId(Guid roomId);
    }
}
