using Cyberpalata.Common;
using Cyberpalata.Common.Filters;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IGameService
    {
        Task<PagedList<GameDto>> GetPagedListAsync(BaseFilter filter);
    }
}
