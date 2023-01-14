using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class RoomRepository : IRoomRepository
    {

        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Room entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<Room> ReadAsync(Guid id)
        {
            return await _context.Rooms.SingleAsync(r => r.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await ReadAsync(id);
            _context.Rooms.Remove(entity);
        }

        private PagedList<Room> GetPageList(int pageNumber)
        {
            var list = _context.Rooms.Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        private PagedList<Room> GetPageList(int pageNumber, RoomType type)
        {
            var list = _context.Rooms.Where(r=>r.Type == type).Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type)
        {
            return await Task.Run(() => GetPageList(pageNumber, type));
        }
    }
}
