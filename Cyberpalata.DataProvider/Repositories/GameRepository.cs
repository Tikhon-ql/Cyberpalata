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
        public async Task CreateAsync(Game entity)
        {
            await _context.Games.AddAsync(entity);
        }

        public async Task<Maybe<Game>> ReadAsync(Guid id)
        {
            var game = await _context.Games.SingleAsync(f => f.Id == id);
            return game;
        }
        public void Delete(Game game)
        {
            _context.Games.Remove(game);
        }
            
        private PagedList<Maybe<Game>> GetPageList(int pageNumber)
        {
            var list = _context.Games.Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<Game>)item);
            return new PagedList<Maybe<Game>>(list.ToList(), pageNumber, 10, _context.Games.Count());
        }

        public async Task<PagedList<Maybe<Game>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
