using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Game entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Games.Add(entity);
            _context.SaveChanges();
        }

        public Game Read(Guid id)
        {
            var game = _context.Games.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (game == null)
                throw new ArgumentException(nameof(id), $"Not found game with id: {id}");
            return game;
        }

        public void Update(Game entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            //var game = _context.Games.AsNoTracking().FirstOrDefault(g => g.Id == id);
            //if (game == null)
            //    throw new ArgumentException(nameof(id), $"Not found game with id: {id}");
            var game = _context.Games.AsNoTracking().Single(g => g.Id == id);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
            
        public PagedList<Game> GetPageList(int pageNumber)
        {
            var list = _context.Games.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Game>(list.ToList(), pageNumber, 10, _context.Games.Count());
        }
    }
}
