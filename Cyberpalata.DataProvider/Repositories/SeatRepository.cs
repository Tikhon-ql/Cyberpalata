using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Models;

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
