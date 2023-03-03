using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task<Maybe<List<Booking>>> GetActualBookingsByRoomId(Guid roomId)
        {
            var bookings = await _context.Bookings.Where(b => b.Date > DateTime.Now && b.RoomId == roomId).ToListAsync();
            return bookings;
        }
    }
}
