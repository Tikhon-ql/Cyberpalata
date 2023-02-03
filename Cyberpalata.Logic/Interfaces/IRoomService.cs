using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Booking;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IRoomService : IService<RoomDto>
    {
        Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber, RoomType type);
        Task<PagedList<RoomDto>> GetVipRoomsAsync(int pageNumber, RoomType type);
        Task<PagedList<RoomDto>> GetCommonRoomsAsync(int pageNumber, RoomType type);
        Task<Result> AddBookingToRoom(Guid userId,BookingCreateRequest request);
        //Task<Maybe<List<SeatDto>>> GetRoomFreeSeats(Guid roomId);
    }
}
