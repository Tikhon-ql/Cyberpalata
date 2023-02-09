using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PcRepository :BaseRepository<Pc>, IPcRepository
    {
        public PcRepository(ApplicationDbContext context, IConfiguration configuration): base(context, configuration)
        {
        }

        public override async Task<PagedList<Pc>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Pcs.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Pc>(list, pageNumber, 10, _context.Pcs.Count());
        }
    }
}
