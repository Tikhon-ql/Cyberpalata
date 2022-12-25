using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
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
    internal class PeripheryRepository : IPeripheryRepository
    {
        private readonly ApplicationDbContext _context;
        public PeripheryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Periphery entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Peripheries.AddAsync(entity);
        }

        public async Task<Periphery> ReadAsync(Guid id)
        {
            var periphery = await _context.Peripheries.SingleAsync(h => h.Id == id);
            return periphery;
        }


        public async Task DeleteAsync(Guid id)
        {
            var periphery = await _context.Peripheries.SingleAsync(g => g.Id == id);
            _context.Peripheries.Remove(periphery);
        }

        private PagedList<Periphery> GetPageList(int pageNumber)
        {
            var list = _context.Peripheries.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Periphery>(list.ToList(), pageNumber, 10, _context.Peripheries.Count());
        }

        public async Task<PagedList<Periphery>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
