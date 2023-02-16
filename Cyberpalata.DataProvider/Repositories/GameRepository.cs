using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Configuration;

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
