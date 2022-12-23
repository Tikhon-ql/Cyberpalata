using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Rooms;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Room entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Rooms.Add(entity);
            _context.SaveChanges();
        }

        public Room Read(Guid id)
        {
            var module = _context.Rooms.AsNoTracking().FirstOrDefault(m => m.Id == id);
            if (module == null)
                throw new ArgumentException(nameof(id), $"Not found module with id: {id}");
            return module;
        }

        public void Update(Room entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var module = _context.Rooms.AsNoTracking().FirstOrDefault(m => m.Id == id);
            if (module == null)
                throw new ArgumentException(nameof(id), $"Not found module with id: {id}");
            _context.Rooms.Remove(module);
            _context.SaveChanges();
        }

        public PagedList<Room> GetPageList(int pageNumber)
        {
            var list = _context.Rooms.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Room>(list.ToList(), pageNumber, 10, _context.Rooms.Count());
        }
    }
}
