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
            MenuItemMapConfig.CreateMap(this);
            PcMapConfig.CreateMap(this);
            PeripheryMapConfig.CreateMap(this);
            GameConsoleMapConfig.CreateMap(this);
            UserRefreshTokenMapConfig.CreateMap(this);
            RoomMapConfig.CreateMap(this);
            BookingMapConfig.CreateMap(this);
            PrizeMapConfig.CreateMap(this);
            TeamMapConfig.CreateMap(this);
            UserMapConfig.CreateMap(this);
            TournamentMapConfig.CreateMap(this);
            FiltersMapConfig.CreateMap(this);
            TeamMemberMapConfig.CreateMap(this);
            BatleMapConfig.CreateMap(this);
            RoundMapConfig.CreateMap(this);
        }
    }
}
