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
    internal static class PriceMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Price, PriceDto>();
            profile.CreateMap<PriceDto, Price>();
            profile.CreateMap<PagedList<Price>, PagedList<PriceDto>>();
            profile.CreateMap<Maybe<Price>, Maybe<PriceDto>>();
            profile.CreateMap<Maybe<List<Price>>, Maybe<List<PriceDto>>>();
        }
    }
}
