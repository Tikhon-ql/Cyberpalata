using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameConsoleRepository : IGameConsoleRepository
    {

        private readonly ApplicationDbContext _context;

        public GameConsoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(GameConsole entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.GameConsoles.AddAsync(entity);
        }

        public async Task<GameConsole> ReadAsync(Guid id)
        {
            return await _context.GameConsoles.SingleAsync(gc => gc.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var console = await _context.GameConsoles.SingleAsync(gc => gc.Id == id);
            _context.GameConsoles.Remove(console);
        }

        private PagedList<GameConsole> GetPageList(int pageNumber)
        {
            var list = _context.GameConsoles.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<GameConsole>(list.ToList(), pageNumber, 10, _context.GameConsoles.Count());
        }

        public async Task<PagedList<GameConsole>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
