using CSharpFunctionalExtensions;
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
            var res = await _context.GameConsoles.FirstOrDefaultAsync(gc => gc.Id == id);
            return res;
        }

        public void Delete(GameConsole console)
        {
            _context.GameConsoles.Remove(console);
        }

        public async Task<PagedList<GameConsole>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.GameConsoles.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<GameConsole>(list, pageNumber, 10, _context.GameConsoles.Count());
        }

        //public async Task<Maybe<List<GameConsole>>> GetByGameConsoleRoomIdAsync(Guid roomId)
        //{
        //    var res = await _context.GameConsoles.Where(gc => gc.ConsoleRoom.Id == roomId).ToListAsync();
        //    return res;
        //}
    }
}
