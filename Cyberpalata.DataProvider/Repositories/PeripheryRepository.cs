using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Context;
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
            await _context.Peripheries.AddAsync(entity);
        }

        public async Task<Maybe<Periphery>> ReadAsync(Guid id)
        {
            var periphery = await _context.Peripheries.SingleAsync(h => h.Id == id);
            return periphery;
        }


        public void Delete(Periphery periphery)
        {
            _context.Peripheries.Remove(periphery);
        }

        private PagedList<Maybe<Periphery>> GetPageList(int pageNumber)
        {
            var list = _context.Peripheries.Include(p => p.Type).Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<Periphery>)item);
            return new PagedList<Maybe<Periphery>>(list.ToList(), pageNumber, 10, _context.Peripheries.Count());
        }

        public async Task<PagedList<Maybe<Periphery>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        public async Task<List<Maybe<Periphery>>> GetByGamingRoomId(Guid roomId)
        {
            return await _context.Peripheries.Include(p=>p.Type).Where(p => p.GamingRoom.Id == roomId).Select(item => (Maybe<Periphery>)item).ToListAsync();
        }
    }
}
