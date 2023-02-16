using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
