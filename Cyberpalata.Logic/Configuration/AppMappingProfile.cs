using AutoMapper;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Models.Rooms;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using Cyberpalata.Logic.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System.Reflection.Metadata;

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<Price, PriceDto>();
            CreateMap<PagedList<Price>, PagedList<PriceDto>>();
            CreateMap<Seat,SeatDto>();
            CreateMap<Game, GameDto>();
            CreateMap<PagedList<Game>, PagedList<GameDto>>();
            CreateMap<Periphery, PeripheryDto>();
            CreateMap<PagedList<Periphery>, PagedList<PeripheryDto>>();
            CreateMap<Pc, PcDto>();
            CreateMap<PagedList<Pc>,PagedList<PcDto>>();
            CreateMap<GameConsole, GameConsoleDto>();
            CreateMap<PagedList<GameConsole>, PagedList<GameConsoleDto>>();
            CreateMap<GameConsoleRoom, GameConsoleRoomDto>();
        }
    }
}
