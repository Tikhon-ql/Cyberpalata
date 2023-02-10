using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Booking;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IBookingService
    {
        Task<Maybe<BookingDto>> ReadAsync(Guid id);
        Task<PagedList<BookingDto>> GetPagedListAsync(int pageNumber, Guid userId);
    }
}
