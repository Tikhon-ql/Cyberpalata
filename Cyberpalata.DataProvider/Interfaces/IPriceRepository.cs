using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        //Task<Maybe<List<Price>>> GetByRoomIdAsync(Guid roomId);
    }
}
