using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories.Room
{
    internal class GamingRoomRepository : RoomRepository, IGamingRoomRepository
    {
        public GamingRoomRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(GamingRoom entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<GamingRoom> ReadAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return (GamingRoom)_context.Rooms.Include(r => r.Prices).Include(r => r.Seats).Include(r => ((GamingRoom)r).Pcs).Single(r => r.Id == id);
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await ReadAsync(id);
            _context.Rooms.Remove(entity);
        }


        //...........


        public List<Periphery> GetPeripheries(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<GamingRoom>> GetPageListAsync(int pageNumber)
        {
            throw new NotImplementedException();
        }


        public List<Pc> GetPcs(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
