using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        List<Maybe<MenuItem>> GetByLoungeId(Guid roomId);
    }
}
