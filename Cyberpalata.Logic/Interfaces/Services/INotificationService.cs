using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface INotificationService
    {
        Task CreateNotificaiton(NotificationDto notification);
        Task SetNotificationProcededDate(List<NotificationDto> notifications, Guid userId);
        Task<PagedList<NotificationDto>> GetPagedList(NotificationFilterBL filter);
    }
}
