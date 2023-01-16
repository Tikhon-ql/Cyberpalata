using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
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
            await _context.GameConsoles.AddAsync(entity);
        }

        public async Task<Maybe<GameConsole>> ReadAsync(Guid id)
        {
            return await _context.GameConsoles.SingleAsync(gc => gc.Id == id);
        }

        public void Delete(GameConsole console)
        {
            _context.GameConsoles.Remove(console);
        }

        private PagedList<Maybe<GameConsole>> GetPageList(int pageNumber)
        {
            var list = _context.GameConsoles.Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<GameConsole>)item);
            return new PagedList<Maybe<GameConsole>>(list.ToList(), pageNumber, 10, _context.GameConsoles.Count());
        }

        public async Task<PagedList<Maybe<GameConsole>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        public async Task<List<Maybe<GameConsole>>> GetByGameConsoleRoomIdAsync(Guid roomId)
        {
            return await _context.GameConsoles.Where(gc => gc.ConsoleRoom.Id == roomId).Select(item=>(Maybe<GameConsole>)item).ToListAsync();
        }
    }
}
