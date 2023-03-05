using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class TeamJoinRequestMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<TeamJoinRequest, TeamJoinRequestDto>();
            profile.CreateMap<TeamJoinRequestDto, TeamJoinRequest>();
            profile.CreateMap<PagedList<TeamJoinRequest>, PagedList<TeamJoinRequestDto>>();
            profile.CreateMap<PagedList<TeamJoinRequestDto>, PagedList<TeamJoinRequest>>();
        }
    }
}
