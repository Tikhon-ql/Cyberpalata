﻿using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PcRepository :BaseRepository<Pc>, IPcRepository
    {
        public PcRepository(ApplicationDbContext context): base(context)
        {
        }

        //public override async Task<PagedList<Pc>> GetPageListAsync(BaseFilter filter)
        //{
        //    var list = await _context.Pcs.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        //    return new PagedList<Pc>(list, filter.CurrentPage, filter.PageSize, _context.Pcs.Count());
        //}
    }
}
