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
    internal static class MenuItemMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<MenuItem, MenuItemDto>();
            profile.CreateMap<MenuItemDto, MenuItem>();
            profile.CreateMap<PagedList<MenuItem>, PagedList<MenuItemDto>>();
            profile.CreateMap<Maybe<MenuItem>, Maybe<MenuItemDto>>();
            profile.CreateMap<Maybe<List<MenuItem>>, Maybe<List<MenuItemDto>>>();
        }
    }
}
