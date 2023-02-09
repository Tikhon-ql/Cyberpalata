﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type);
        Task<PagedList<Room>> GetVipRoomsAsync(int pageNumber, RoomType type);
        Task<PagedList<Room>> GetCommonRoomsAsync(int pageNumber, RoomType type);
        Task AddBookingToRoomAsync(Guid roomId,Booking booking);
        Task<Maybe<List<Room>>> GetAll();
    }
}
