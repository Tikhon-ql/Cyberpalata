using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class GameConsoleMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<GameConsole, GameConsoleDto>();
            profile.CreateMap<PagedList<GameConsole>, PagedList<GameConsoleDto>>();
            profile.CreateMap<Maybe<GameConsole>, Maybe<GameConsoleDto>>();
            profile.CreateMap<Maybe<List<GameConsole>>, Maybe<List<GameConsoleDto>>>();
        }
    }
}
