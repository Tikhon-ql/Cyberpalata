﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class BookingMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<BookingDto, Booking>();
            profile.CreateMap<Booking, BookingDto>();
            profile.CreateMap<Maybe<Booking>, Maybe<BookingDto>>();
            profile.CreateMap<PagedList<Booking>, PagedList<BookingDto>>();

            profile.CreateMap<BookingCreateRequest, Booking>()
                .ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dst => dst.Begining, opt => opt.MapFrom(src => src.Begining))
                .ForMember(dst => dst.Ending, opt => opt.MapFrom(src => src.Ending))
                .ForMember(dst => dst.Tariff, opt => opt.MapFrom(src => src.Tariff))
                .ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats.Select(item => new SeatDto { Number = item, IsFree = false })));
        }
    }
}