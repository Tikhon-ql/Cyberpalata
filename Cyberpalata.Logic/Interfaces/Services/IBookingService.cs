using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Filters;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.ViewModel.Response.Booking;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IBookingService
    {
        Task<Maybe<BookingDto>> ReadAsync(Guid id);
        Task<PagedList<BookingDto>> GetPagedListAsync(BaseFilter filter);
        Task<Result<BookingDetailsViewModel>> GetBookingDetail(Guid id);//???
    }
}
