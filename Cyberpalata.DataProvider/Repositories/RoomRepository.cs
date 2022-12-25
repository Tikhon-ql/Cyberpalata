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
    internal class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Room entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<Room> ReadAsync(Guid id)
        {
            var module = await _context.Rooms.SingleAsync(m => m.Id == id);
            return module;
        }

        public async Task DeleteAsync(Guid id)
        {
            var module = await _context.Rooms.SingleAsync(m => m.Id == id);
            _context.Rooms.Remove(module);
        }

        private PagedList<Room> GetPageList(int pageNumber)
        {
            var list = _context.Rooms.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Room>(list.ToList(), pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
