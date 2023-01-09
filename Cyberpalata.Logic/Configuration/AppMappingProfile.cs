﻿using AutoMapper;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System.Reflection.Metadata;
using System.Globalization;

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ApiUser, ApiUserDto>();

            CreateMap<Game, GameDto>();
            CreateMap<PagedList<Game>, PagedList<GameDto>>();
 
            CreateMap<Room, RoomDto>();
            CreateMap<PagedList<Room>, PagedList<RoomDto>>();

            CreateMap<Price, PriceDto>();
            CreateMap<PagedList<Price>, PagedList<PriceDto>>();

            CreateMap<Seat, SeatDto>();
            CreateMap<PagedList<Seat>, PagedList<SeatDto>>();

            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<PagedList<MenuItem>, PagedList<MenuItemDto>>();

            CreateMap<Pc, PcDto>();
            CreateMap<PagedList<Pc>, PagedList<PcDto>>();

            CreateMap<Periphery, PeripheryDto>();
            CreateMap<PagedList<Periphery>, PagedList<PeripheryDto>>();

            CreateMap<GameConsole, GameConsoleDto>();
            CreateMap<PagedList<GameConsole>, PagedList<GameConsoleDto>>();


            //CreateMap<PagedList<ApiUser>, PagedList<ApiUserDto>>();

            CreateMap<UserRefreshToken, UserRefreshTokenDto>();
                //.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                //.ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                //.ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                //.ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));

            //CreateMap<ApiUser, AuthorizationRequest>()
            //    .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
            //    .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
            //    .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
