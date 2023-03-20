using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.ViewModel.Request.Booking;
using Cyberpalata.ViewModel.Request.Filters;
using Cyberpalata.ViewModel.Request.Room;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IRoomService
    {
        Task<PagedList<RoomDto>> GetPagedListAsync(RoomFilterBL filter);
        Task<Result> AddBookingToRoom(Guid userId, BookingCreateViewModel request);
        //Task<Maybe<List<RoomDto>>> SearchRooms(SearchRoomViewModel request);
        Task<Maybe<int>> GetFreeSeatsCount(Guid roomId, RoomFilterBL filter);
    }
}
