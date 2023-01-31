using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
