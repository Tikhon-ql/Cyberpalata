using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task CreateRangeAsync(List<Game> games);
    }
}
