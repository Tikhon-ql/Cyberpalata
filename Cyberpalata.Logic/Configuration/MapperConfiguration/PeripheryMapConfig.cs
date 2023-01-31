using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class PeripheryMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Periphery, PeripheryDto>();
            profile.CreateMap<PagedList<Periphery>, PagedList<PeripheryDto>>();
            profile.CreateMap<Maybe<Periphery>, Maybe<PeripheryDto>>();
            profile.CreateMap<Maybe<List<Periphery>>, Maybe<List<PeripheryDto>>>();
        }
    }
}
