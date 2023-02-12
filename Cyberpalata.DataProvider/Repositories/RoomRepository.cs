﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Filters;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class RoomRepository :BaseRepository<Room>, IRoomRepository
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;

        public RoomRepository(ApplicationDbContext context
            ,IBookingRepository bookingRepository, IUserRepository userRepository):base(context)
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
        }

        //public override async Task<PagedList<Room>> GetPageListAsync(int pageNumber)
        //{
        //    var list = await _context.Rooms.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
        //    return new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        //}

        //public async Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type)
        //{
        //    var list = await _context.Rooms.Include(r => r.Type).Where(r => r.Type.Name == type.Name).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
        //    var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        //    return pagedList;
        //}

        //public async Task<PagedList<Room>> GetVipRoomsAsync(int pageNumber, RoomType type)
        //{
        //    var list = await _context.Rooms.Where(r => r.Type.Name == type.Name && r.IsVip).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
        //    var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        //    return pagedList;
        //}
        //public async Task<PagedList<Room>> GetCommonRoomsAsync(int pageNumber, RoomType type)
        //{
        //    var list = await _context.Rooms.Where(r => r.Type.Name == type.Name && !r.IsVip).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
        //    var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        //    return pagedList;
        //}

        public override async Task<PagedList<Room>> GetPageListAsync(BaseFilter filter)
        {
            IQueryable<Room> rooms = null;//???
            if (filter is RoomFilter)
            {
                var roomFilter = filter as RoomFilter;
                rooms = _context.Rooms.Where(r => r.Type == roomFilter.Type && r.IsVip == roomFilter.IsVip);
            }
            else
                rooms = _context.Rooms;

            var resultList = await rooms.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
            return new PagedList<Room>(resultList, filter.CurrentPage, filter.PageSize, _context.Rooms.Count());
        }

        //public async Task AddBookingToRoomAsync(Guid roomId, Booking booking)
        //{
        //    //A.K.:to complex logic. Repository should just read / save data. In this case you can create booking with all necessary properties filled on a BL

        //    var room = await ReadAsync(roomId);

        //    var seats = room.Value.Seats.Where(s => booking.Seats.FirstOrDefault(seat => seat.Number == s.Number) != null).ToList();

        //    booking.Id = Guid.NewGuid();
           
        //    booking.Seats = seats;

        //    foreach(var seat in seats)
        //    {
        //        seat.Bookings.Add(booking);
        //    }

        //    var user = await _userRepository.ReadAsync(booking.User.Id);
        //    booking.User = user.Value;

        //    booking.Room = room.Value;
        //    room.Value.Bookings.Add(booking);

        //    _context.Bookings.Add(booking);
        //}

        public async Task<List<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
