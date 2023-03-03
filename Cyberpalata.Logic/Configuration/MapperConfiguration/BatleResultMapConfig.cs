using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class BatleResultMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<BatleResult, BatleResultDto>();
        }
    }
}
