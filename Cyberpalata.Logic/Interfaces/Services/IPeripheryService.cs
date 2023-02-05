using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Peripheral;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPeripheryService : IService<PeripheryDto>
    {
        Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId);
    }
}
