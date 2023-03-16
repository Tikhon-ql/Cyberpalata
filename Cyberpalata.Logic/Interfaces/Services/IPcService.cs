using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPcService
    {
        //Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId);
        Task<PagedList<PcDto>> GetPagedList(PcFilterBl filter);
    }
}