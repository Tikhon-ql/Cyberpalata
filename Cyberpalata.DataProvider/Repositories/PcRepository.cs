using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Functional.Maybe;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PcRepository : IPcRepository
    {
        private readonly ApplicationDbContext _context;

        public PcRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Pc entity)
        {
            await _context.Pcs.AddAsync(entity);
        }

        public async Task<Maybe<Pc>> ReadAsync(Guid id)
        {
            var pc = await _context.Pcs.FirstOrDefaultAsync();
            return pc.ToMaybe();
        }

        public void Delete(Pc pc)
        {
            _context.Pcs.Remove(pc);
        }

        public async Task<PagedList<Pc>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Pcs.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Pc>(list, pageNumber, 10, _context.Pcs.Count());
        }

        public async Task<Maybe<Pc>> GetByGamingRoomId(Guid roomId)
        { 
            var pc = await _context.Pcs.FirstOrDefaultAsync(pc => pc.GamingRoom.Id == roomId);
            return pc.ToMaybe();
        }
    }
}
