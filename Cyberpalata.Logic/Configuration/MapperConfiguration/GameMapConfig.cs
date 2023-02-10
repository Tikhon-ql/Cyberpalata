using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class GameMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Game, GameDto>();
            profile.CreateMap<PagedList<Game>, PagedList<GameDto>>();
            profile.CreateMap<Maybe<Game>, Maybe<GameDto>>();
            profile.CreateMap<Maybe<List<Game>>, Maybe<List<GameDto>>>();
        }
    }
}
