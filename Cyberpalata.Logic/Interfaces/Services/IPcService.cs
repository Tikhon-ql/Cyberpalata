using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPcService : IService<PcDto>
    {
        Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId);
    }
}
