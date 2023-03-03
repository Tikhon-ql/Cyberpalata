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
    }
}
