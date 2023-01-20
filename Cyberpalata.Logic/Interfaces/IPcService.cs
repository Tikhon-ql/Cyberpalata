using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPcService : IService<PcDto>
    {
        Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId);
    }
}
