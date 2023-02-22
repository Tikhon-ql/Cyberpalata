using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;

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
            profile.CreateMap<TournamentFilterBL, TournamentFilter>();
        }
    }
}
