using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
