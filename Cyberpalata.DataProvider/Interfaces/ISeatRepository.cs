using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<Maybe<List<Seat>>> GetByRoomIdAsync(Guid roomId);
    }
}
