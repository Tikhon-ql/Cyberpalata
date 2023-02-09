using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class GameConsoleRepository :BaseRepository<GameConsole>, IGameConsoleRepository
    {
        public GameConsoleRepository(ApplicationDbContext context, IConfiguration configuration):base(context, configuration)
        {
        }
        public override async Task<PagedList<GameConsole>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.GameConsoles.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<GameConsole>(list, pageNumber, 10, _context.GameConsoles.Count());
        }
    }
}
