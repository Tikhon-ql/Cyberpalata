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
            await _context.Rooms.AddAsync(entity);
        }

        public async Task<Maybe<Room>> ReadAsync(Guid id)
        {
            return await _context.Rooms.SingleAsync(r => r.Id == id);
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        private PagedList<Maybe<Room>> GetPageList(int pageNumber)
        {
            var list = _context.Rooms.Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<Room>)item).ToList();
            return new PagedList<Maybe<Room>>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Maybe<Room>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        private PagedList<Maybe<Room>> GetPageList(int pageNumber, RoomType type)
        {
            var list = _context.Rooms.Where(r=>r.Type.Name == type.Name).Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<Room>)item).ToList();
            return new PagedList<Maybe<Room>>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Maybe<Room>>> GetPageListAsync(int pageNumber, RoomType type)
        {
            return await Task.Run(() => GetPageList(pageNumber, type));
        }
    }
}
