using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Room;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IRoomService
    {
        Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber, RoomType type);
        Task<PagedList<RoomDto>> GetVipRoomsAsync(int pageNumber, RoomType type);
        Task<PagedList<RoomDto>> GetCommonRoomsAsync(int pageNumber, RoomType type);
        Task<Result> AddBookingToRoom(Guid userId, BookingCreateRequest request);
        Task<Maybe<List<RoomDto>>> SearchRooms(SearchRoomRequest request);
    }
}
