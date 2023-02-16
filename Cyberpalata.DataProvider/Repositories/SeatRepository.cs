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
        public SeatRepository(ApplicationDbContext context):base(context)
        {
        }

        public async Task CreateRangeAsync(List<Seat> seats)
        {
            await _context.Seats.AddRangeAsync(seats);
        }
    }
}
