using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class RoomRepository :BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context):base(context)
        {
        }
        public async Task<List<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
