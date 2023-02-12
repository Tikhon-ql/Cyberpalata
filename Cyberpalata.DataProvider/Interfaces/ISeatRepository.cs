using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        //A.K.: it is better to return the result of the operation. Result<List<Guid,Seat property to understand>> will be ok. Clear usings
        Task CreateRangeAsync(List<Seat> seats);
    }
}
