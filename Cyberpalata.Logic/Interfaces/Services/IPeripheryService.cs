using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Peripheral;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IPeripheryService
    {
        public Task<PagedList<PeripheryDto>> GetPageList(PeripheriesFilterBl filter);
        //Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId);
    }
}
