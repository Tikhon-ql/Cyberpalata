using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Rooms;
using Microsoft.EntityFrameworkCore;

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
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            return room;
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Rooms.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
        }

        public async Task<PagedList<Room>> GetPageListAsync(int pageNumber, RoomType type)
        {
            var list = await _context.Rooms.Where(r => r.Type.Name == type.Name).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            var pagedList = new PagedList<Room>(list, pageNumber, 10, _context.Rooms.Count());
            return pagedList;
        }
    }
}
