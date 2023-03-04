using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
