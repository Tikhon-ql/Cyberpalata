using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class FiltersMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<BaseFilterBL, BaseFilter<BaseEntity>>();
            profile.CreateMap<RoomFilterBL, RoomFilter>();
            profile.CreateMap<BookingFilterBL, BookingFilter>();
            profile.CreateMap<TeamFilterBL,TeamFilter>();
        }
    }
}
