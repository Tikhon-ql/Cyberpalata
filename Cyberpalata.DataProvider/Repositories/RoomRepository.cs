using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class RoomRepository : IRoomRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IBookingRepository _bookingRepository;
        private readonly IApiUserRepository _userRepository;

        public RoomRepository(ApplicationDbContext context, IBookingRepository bookingRepository, IApiUserRepository userRepository)
        {
            _context = context;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
        }

        public async Task CreateAsync(Room entity)
        {
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<Maybe<Room>> ReadAsync(Guid id)
        {
            //Include everything?
            var room = await _context.Rooms.AsTracking().FirstOrDefaultAsync(r => r.Id == id);
            return room;
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Rooms.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type)
        {
            var list = await _context.Rooms.Include(r => r.Type).Where(r => r.Type.Name == type.Name).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
            return pagedList;
        }
        //????????????????????????????

        public async Task<PagedList<Room>> GetVipRoomsAsync(int pageNumber, RoomType type)
        {
            var list = await _context.Rooms.Where(r => r.Type.Name == type.Name && r.IsVip).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
            return pagedList;
        }
        public async Task<PagedList<Room>> GetCommonRoomsAsync(int pageNumber, RoomType type)
        {
            var list = await _context.Rooms.Where(r => r.Type.Name == type.Name && !r.IsVip).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
            return pagedList;
        }

        public async Task AddBookingToRoomAsync(Guid roomId, Booking booking)
        {
            var room = await ReadAsync(roomId);
            
            //room.Value.Bookings.Add(new Booking());
            //var price = room.Value.Prices.FirstOrDefault(p => p.Hours == booking.Tariff.Hours);

            var seats = room.Value.Seats.Where(s => booking.Seats.FirstOrDefault(seat => seat.Number == s.Number) != null).ToList();

            //booking.Room = room.Value;
            booking.Id = Guid.NewGuid();
           
            booking.Seats = seats;

            foreach(var seat in seats)
            {
                seat.Bookings.Add(booking);
            }

            //booking.Tariff = price;

            var user = await _userRepository.ReadAsync(booking.User.Id);
            booking.User = user.Value;
            booking.Room = room.Value;
            room.Value.Bookings.Add(booking);
            _context.Bookings.Add(booking);
            Console.WriteLine("Hello");
        }

        //public async Task<Maybe<List<Seat>>> GetRoomFreeSeats(Guid roomId)
        //{
        //    //var room = await _context.Rooms.Include(r => r.Seats).FirstOrDefaultAsync(r => r.Id == roomId);

        //    //if (room == null)//?????????? can it return null?
        //    //    return Maybe.None;
        //    //var result = new List<Seat>();
        //    //foreach (var seat in room.Seats)
        //    //{
        //    //    if (await _bookingRepository.CheckIsSeatFreeAsync(seat))
        //    //    {
        //    //        result.Add(seat);
        //    //    }
        //    //}

        //    return result;
        //}
    }
}
