using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task CreateRangeAsync(List<Seat> seats);
    }
}
