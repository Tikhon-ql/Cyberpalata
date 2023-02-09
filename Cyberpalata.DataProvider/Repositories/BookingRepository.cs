using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context, IConfiguration configuration):base(context, configuration)
        {
        }

        public override async Task<PagedList<Booking>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Bookings.Skip((pageNumber - 1) * 20).Take(20).ToListAsync();
            return new PagedList<Booking>(list, pageNumber, 20,_context.Bookings.Count());
        }

        public async Task<PagedList<Booking>> GetPagedListAsync(int pageNumber, Guid userId)
        {
            int pageSize = int.Parse(_configuration["PaginationSettings:bookingByIdPageSize"]);
            var usersBookings = _context.Bookings.Where(b => b.User.Id == userId);
            var list = usersBookings.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<Booking>(list,pageNumber,pageSize,usersBookings.Count());
        }

        public async Task<Maybe<List<Booking>>> GetActualBookingsByRoomId(Guid roomId)
        {
            var bookings = await _context.Bookings.Where(b => b.Date > DateTime.Now && b.RoomId == roomId).ToListAsync();
            return bookings;
        }
    }
}
