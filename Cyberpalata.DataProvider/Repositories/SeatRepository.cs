using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;
using CSharpFunctionalExtensions;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class SeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext _context;
        public SeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Seat entity)
        {
            await _context.Seats.AddAsync(entity);
        }
        public async Task CreateRangeAsync(List<Seat> seats)
        {
            await _context.Seats.AddRangeAsync(seats);
        }

        public async Task<Maybe<Seat>> ReadAsync(Guid id)
        {
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            return seat;
        }

        public void Delete(Seat entity)
        {
            _context.Seats.Remove(entity);
        }

        public async Task<PagedList<Seat>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Seats.Skip((pageNumber - 1) * 50).Take(50).ToListAsync();
            return new PagedList<Seat>(list, pageNumber, 50, _context.Seats.Count());
        }

        public async Task<List<Seat>> GetByRoomIdAsync(Guid roomId)
        {
            var list = await _context.Seats.Where(s=>s.Room.Id == roomId).ToListAsync();
            return list;
        }
    }
}
