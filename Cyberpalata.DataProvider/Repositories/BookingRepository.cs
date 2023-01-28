using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Booking entity)
        {
            await _context.Bookings.AddAsync(entity);
        }
        public async Task<Maybe<Booking>> ReadAsync(Guid id)
        {
            Maybe<Booking> booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking;
        }

        public void Delete(Booking entity)
        {
            _context.Bookings.Remove(entity);
        }

        public async Task<PagedList<Booking>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Bookings.Skip((pageNumber - 1) * 20).Take(20).ToListAsync();
            return new PagedList<Booking>(list, pageNumber, 20,_context.Bookings.Count());
        }

        //????????????????????/shit code
        public async Task<bool> CheckIsSeatFreeAsync(Seat seat)
        {
            var result = await _context.Bookings.Where(b=>b.Ending < DateTime.Now).FirstOrDefaultAsync(b => b.Seats.Contains(seat));
            if (result == null)
                return true;
            return false;
        }
    }
}
