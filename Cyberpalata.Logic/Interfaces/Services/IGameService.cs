using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IGameService
    {
        Task<PagedList<GameDto>> GetPagedListAsync(BaseFilterBL filter);
    }
}
