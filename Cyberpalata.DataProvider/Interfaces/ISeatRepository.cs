using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<List<Seat>> GetByRoomIdAsync(Guid roomId);
        Task CreateRangeAsync(List<Seat> seats);
    }
}
