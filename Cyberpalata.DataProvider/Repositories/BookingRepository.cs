using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Filters;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context):base(context)
        {
        }

        //???
        public override async Task<PagedList<Booking>> GetPageListAsync(BaseFilter filter)
        {
            IQueryable<Booking> bookings = null;

            if (filter is BookingFilter)
                bookings = _context.Bookings.Where(b => b.User.Id == ((BookingFilter)filter).UserId);
            else
                bookings = _context.Bookings;

            var resultList = await bookings.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
            return new PagedList<Booking>(resultList,filter.CurrentPage, filter.PageSize,bookings.Count());
        }

        public async Task<Maybe<List<Booking>>> GetActualBookingsByRoomId(Guid roomId)
        {
            var bookings = await _context.Bookings.Where(b => b.Date > DateTime.Now && b.RoomId == roomId).ToListAsync();
            return bookings;
        }
    }
}
