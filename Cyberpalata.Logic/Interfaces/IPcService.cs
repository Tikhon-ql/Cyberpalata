using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IPcService : IService<PcDto>
    {
        Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId);
    }
}
