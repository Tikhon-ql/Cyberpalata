using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class RoundMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Round, RoundDto>();
            profile.CreateMap<RoundDto, Round>();
            profile.CreateMap<RoundCreateViewModel, RoundDto>();
        }
    }
}
