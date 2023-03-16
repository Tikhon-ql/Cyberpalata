using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class NotificationMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Notification, NotificationDto>();
            profile.CreateMap<NotificationDto, Notification>();
            profile.CreateMap<PagedList<Notification>, PagedList<NotificationDto>>();
        }
    }
}
