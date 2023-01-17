using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var pc = await _context.Pcs.SingleAsync();
            return pc.ToMaybe();
        }

        public void Delete(Pc pc)
        {
            _context.Pcs.Remove(pc);
        }

        private PagedList<Maybe<Pc>> GetPageList(int pageNumber)
        {
            var list = _context.Pcs.Skip((pageNumber - 1) * 10).Take(10).Select(item=>item.ToMaybe()).ToList();
            return new PagedList<Maybe<Pc>>(list, pageNumber, 10, _context.Pcs.Count());
        }

        public Task<PagedList<Maybe<Pc>>> GetPageListAsync(int pageNumber)
        {
            return Task.Run(() => GetPageList(pageNumber));
        }

        public async Task<Maybe<Pc>> GetByGamingRoomId(Guid roomId)
        {
            var res = await _context.Pcs.SingleAsync(pc => pc.GamingRoom.Id == roomId);
            return res.ToMaybe();
        }
    }
}
