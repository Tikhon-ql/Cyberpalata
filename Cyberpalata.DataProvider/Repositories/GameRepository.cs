using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context):base(context)
        {
        }
        public async Task CreateRangeAsync(List<Game> games)
        {
            await _context.Games.AddRangeAsync(games);
        }

        //public override async Task<PagedList<Game>> GetPageListAsync(BaseFilter filter)
        //{
        //    var list = await _context.Games.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();
        //    return new PagedList<Game>(list, filter.CurrentPage, filter.PageSize, _context.Games.Count());
        //}
    }
}
