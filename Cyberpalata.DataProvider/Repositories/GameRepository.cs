using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Result> CreateAsync(Game entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Games.AddAsync(entity);
            return Result.Ok();
        }

        public async Task<Game> ReadAsync(Guid id)
        {
            var game = await _context.Games.SingleAsync(f => f.Id == id);
            return game;
        }
        public async Task DeleteAsync(Guid id)
        {
            var game = await _context.Games.SingleAsync(g => g.Id == id);
            _context.Games.Remove(game);
        }
            
        private PagedList<Game> GetPageList(int pageNumber)
        {
            var list = _context.Games.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Game>(list.ToList(), pageNumber, 10, _context.Games.Count());
        }

        public async Task<PagedList<Game>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
