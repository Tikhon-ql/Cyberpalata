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

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Device, DeviceDto>();
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<Price, PriceDto>();
            CreateMap<Seat,SeatDto>();
            CreateMap<Game, GameDto>();
            CreateMap<Periphery, PeripheryDto>();
            CreateMap<PagedList<Game>, PagedList<GameDto>>();
        }
    }
}
