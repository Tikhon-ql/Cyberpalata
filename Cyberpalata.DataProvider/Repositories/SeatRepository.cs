using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(ApplicationDbContext context, IConfiguration configuration):base(context, configuration)
        {
        }

        public async Task CreateRangeAsync(List<Seat> seats)
        {
            await _context.Seats.AddRangeAsync(seats);
        }

        public override async Task<PagedList<Seat>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Seats.Skip((pageNumber - 1) * 50).Take(50).ToListAsync();
            return new PagedList<Seat>(list, pageNumber, 50, _context.Seats.Count());
        }
    }
}
