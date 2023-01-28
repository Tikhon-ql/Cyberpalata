using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IPcRepository : IRepository<Pc>
    {
        //Task<Maybe<Pc>> GetByGamingRoomId(Guid roomId);
    }
}   
