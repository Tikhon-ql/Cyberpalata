using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Filters;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.ViewModel.Request.Booking;
using Cyberpalata.ViewModel.Request.Room;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IRoomService
    {
        //Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber, RoomType type);
        //Task<PagedList<RoomDto>> GetVipRoomsAsync(int pageNumber, RoomType type);
        //Task<PagedList<RoomDto>> GetCommonRoomsAsync(int pageNumber, RoomType type);
        Task<PagedList<RoomDto>> GetPagedListAsync(BaseFilter filter);
        Task<Result> AddBookingToRoom(Guid userId, BookingCreateViewModel request);
        Task<Maybe<List<RoomDto>>> SearchRooms(SearchRoomViewModel request);
    }
}
