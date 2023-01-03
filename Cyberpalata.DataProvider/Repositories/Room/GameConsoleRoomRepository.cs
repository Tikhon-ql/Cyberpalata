using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories.Room
{
    internal class GameConsoleRoomRepository : RoomRepository, IGameConsoleRoomRepository
    {
        public GameConsoleRoomRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(GameConsoleRoom entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<GameConsoleRoom> ReadAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                return (GameConsoleRoom)_context.Rooms.Include(g => ((GameConsoleRoom)g).Consoles).Include(p => p.Prices).Single(g => g.Id == id);
            });
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<GameConsoleRoom>> GetPageListAsync(int pageNumber)
        {
            throw new NotImplementedException();
        }

        public List<GameConsole> GetGameConsoles(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
