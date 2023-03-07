using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IMessageService
    {
        Task CreateAsync(MessageViewModel message);
        Task<PagedList<MessageDto>> GetPagedList(MessageFilterBL filter);
    }
}
