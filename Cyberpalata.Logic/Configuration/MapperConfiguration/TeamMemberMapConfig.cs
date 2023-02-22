using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class TeamMemberMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<TeamMember, TeamMemberDto>();
        }
    }
}
