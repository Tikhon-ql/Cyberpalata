using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.ViewModel.Request.Bookings;
using Cyberpalata.ViewModel.Response.Booking;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IBookingService
    {
        Task<Maybe<BookingDto>> ReadAsync(Guid id);
        Task<PagedList<BookingDto>> GetPagedListAsync(BookingFilterBL filter);
        Task<Result<BookingDetailsViewModel>> GetBookingDetail(Guid id);
        //Create payment service
        Task<Result> BookingPay(BookingFinalizationViewModel viewModel, Guid userId);
    }
}
