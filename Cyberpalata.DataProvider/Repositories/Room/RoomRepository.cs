using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories.Room
{
    internal class RoomRepository : IRoomRepository
    {
        protected readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual async Task<List<Tuple<string, string>>> GetRoomNameWithIdAsync()
        {
            return await _context.Rooms.Select(r => new Tuple<string, string>(r.Id.ToString(), r.Name)).ToListAsync();
        }










        public List<Price> GetPrices(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Guid>> GetRoomIdsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRoomNamesAsync()
        {
            throw new NotImplementedException();
        }


        public List<Seat> GetSeats(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
