using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PeripheryRepository : IPeripheryRepository
    {
        private readonly ApplicationDbContext _context;
        public PeripheryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Periphery entity)
        {
            await _context.Peripheries.AddAsync(entity);
        }

        public async Task<Maybe<Periphery>> ReadAsync(Guid id)
        {
            var periphery = await _context.Peripheries.FirstOrDefaultAsync(h => h.Id == id);
            return periphery.ToMaybe();
        }


        public void Delete(Periphery periphery)
        {
            _context.Peripheries.Remove(periphery);
        }

        public async Task<PagedList<Periphery>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Peripheries.Include(p => p.Type).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Periphery>(list, pageNumber, 10, _context.Peripheries.Count());
        }

        public async Task<Maybe<List<Periphery>>> GetByGamingRoomId(Guid roomId)
        {
            var roomPeripheries = await _context.Peripheries.Include(p => p.Type).Where(p => p.GamingRoom.Id == roomId).ToListAsync();
            return roomPeripheries.ToMaybe();
        }
    }
}
