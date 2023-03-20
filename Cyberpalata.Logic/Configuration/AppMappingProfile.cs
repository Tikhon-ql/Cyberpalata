using AutoMapper;
using Cyberpalata.Logic.Configuration.MapperConfiguration;

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            RoleMapConfig.CreateMap(this);
            GameMapConfig.CreateMap(this);
            SeatMapConfig.CreateMap(this);
            PcMapConfig.CreateMap(this);
            PeripheryMapConfig.CreateMap(this);
            UserRefreshTokenMapConfig.CreateMap(this);
            RoomMapConfig.CreateMap(this);
            BookingMapConfig.CreateMap(this);
            TeamMemberMapConfig.CreateMap(this);
            TeamMapConfig.CreateMap(this);
            UserMapConfig.CreateMap(this);
            TournamentMapConfig.CreateMap(this);
            FiltersMapConfig.CreateMap(this);
            BatleMapConfig.CreateMap(this);
            TeamJoinRequestMapConfig.CreateMap(this);
            NotificationMapConfig.CreateMap(this);
            MessageMapConfig.CreateMap(this);
            ChatMapConfig.CreateMap(this);
        }
    }
}
