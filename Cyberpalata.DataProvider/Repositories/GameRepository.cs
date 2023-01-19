using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;
using CSharpFunctionalExtensions;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Game entity)
        {
            await _context.Games.AddAsync(entity);
        }

        public async Task<Maybe<Game>> ReadAsync(Guid id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(f => f.Id == id);
            return game;
        }
        public void Delete(Game game)
        {
            _context.Games.Remove(game);
        }
            
        public async Task<PagedList<Game>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Games.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Game>(list, pageNumber, 10, _context.Games.Count());
        }
    }
}
