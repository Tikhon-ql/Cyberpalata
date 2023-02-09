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
        public GameRepository(ApplicationDbContext context, IConfiguration configuration):base(context,configuration)
        {
        }
        public async Task CreateRangeAsync(List<Game> games)
        {
            await _context.Games.AddRangeAsync(games);
        }

        public override async Task<PagedList<Game>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Games.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Game>(list, pageNumber, 10, _context.Games.Count());
        }
    }
}
