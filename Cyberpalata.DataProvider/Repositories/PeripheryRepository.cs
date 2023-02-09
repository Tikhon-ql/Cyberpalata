using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PeripheryRepository :BaseRepository<Periphery>, IPeripheryRepository
    {
        public PeripheryRepository(ApplicationDbContext context, IConfiguration configuration):base(context, configuration)
        {
        }
        public override async Task<PagedList<Periphery>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Peripheries.Include(p => p.Type).Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Periphery>(list, pageNumber, 10, _context.Peripheries.Count());
        }
    }
}
