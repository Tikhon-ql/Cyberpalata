using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Context;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PeripheryRepository :BaseRepository<Periphery>, IPeripheryRepository
    {
        public PeripheryRepository(ApplicationDbContext context):base(context)
        {
        }
        //public override async Task<PagedList<Periphery>> GetPageListAsync(BaseFilter filter)
        //{
        //    var list = await _context.Peripheries.Include(p => p.Type).Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        //    return new PagedList<Periphery>(list, filter.CurrentPage, filter.PageSize, _context.Peripheries.Count());
        //}
    }
}
