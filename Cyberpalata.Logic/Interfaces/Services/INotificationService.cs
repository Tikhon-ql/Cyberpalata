using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface INotificationService
    {
        Task SetNotificationProcededDate(List<NotificationDto> notifications, Guid userId);
        Task<PagedList<NotificationDto>> GetPagedList(NotificationFilterBL filter);
    }
}
