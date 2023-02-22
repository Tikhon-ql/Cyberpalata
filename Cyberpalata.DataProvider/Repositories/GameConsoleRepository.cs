using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameConsoleRepository :BaseRepository<GameConsole>, IGameConsoleRepository
    {
        public GameConsoleRepository(ApplicationDbContext context):base(context)
        {
        }
        //public override async Task<PagedList<GameConsole>> GetPageListAsync(BaseFilter filter)
        //{
        //    var list = await _context.GameConsoles.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        //    return new PagedList<GameConsole>(list, filter.CurrentPage, filter.PageSize, _context.GameConsoles.Count());
        //}
    }
}
