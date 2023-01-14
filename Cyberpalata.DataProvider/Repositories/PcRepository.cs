using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
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
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Pcs.AddAsync(entity);
        }

        public async Task<Pc> ReadAsync(Guid id)
        {
            var pc = await _context.Pcs.SingleAsync();
            return pc;
        }

        public async Task DeleteAsync(Guid id)
        {
            var pc = await ReadAsync(id);
            _context.Pcs.Remove(pc);
        }

        private PagedList<Pc> GetPageList(int pageNumber)
        {
            var list = _context.Pcs.Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<Pc>(list, pageNumber, 10, _context.Pcs.Count());
        }

        public Task<PagedList<Pc>> GetPageListAsync(int pageNumber)
        {
            return Task.Run(() => GetPageList(pageNumber));
        }

        public async Task<Pc> GetByGamingRoomId(Guid roomId)
        {
            return await _context.Pcs.SingleAsync(pc => pc.GamingRoom.Id == roomId);
        }
    }
}
