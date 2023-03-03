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
    }
}
