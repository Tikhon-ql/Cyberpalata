﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class RoomMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.AllowNullCollections = true;
            profile.AllowNullDestinationValues = true;
            profile.CreateMap<Room, RoomDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                //.ForMember(dst => dst.Pc, opt => opt.MapFrom(src => src.Pc))
                //.ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.Prices, opt => opt.MapFrom(src => src.Prices))
                .ForMember(dst => dst.Consoles, opt => opt.MapFrom(src => src.Consoles))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            profile.CreateMap<PagedList<Room>, PagedList<RoomDto>>();
            profile.CreateMap<RoomDto, Room>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                //.ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                //.ForMember(dst => dst.Pc, opt => opt.MapFrom(src => src.Pc))
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.Prices, opt => opt.MapFrom(src => src.Prices))
                .ForMember(dst => dst.Consoles, opt => opt.MapFrom(src => src.Consoles))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            profile.CreateMap<Maybe<Room>, Maybe<RoomDto>>();
            profile.CreateMap<PagedList<Room>, PagedList<RoomDto>>();
            profile.CreateMap<PagedList<RoomDto>, PagedList<Room>>();
        }
    }
}