using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class FiltersMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<RoomFilterBL, RoomFilter>();
            profile.CreateMap<BookingFilterBL, BookingFilter>();
            profile.CreateMap<TeamFilterBL,TeamFilter>();
            profile.CreateMap<TournamentFilterBL, TournamentFilter>();
            profile.CreateMap<BatleFilterBL, BatleFilter>();
            profile.CreateMap<NotificationFilterBL, NotificationFilter>();
            profile.CreateMap<GameFilterBl, GameFilter>();
            profile.CreateMap<TeamJoinRequestFilterBL, TeamJoinRequestFilter>();
            profile.CreateMap<TeamJoinRequestFilter, TeamJoinRequestFilterBL>();
            profile.CreateMap<ChatFilterBL, ChatFilter>();
            profile.CreateMap<MessageFilterBL, MessageFilter>();
        }
    }
}
