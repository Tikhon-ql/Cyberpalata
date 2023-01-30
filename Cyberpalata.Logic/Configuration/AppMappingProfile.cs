using AutoMapper;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models.Booking;

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;
         
            CreateMap<Game, GameDto>();
            CreateMap<PagedList<Game>, PagedList<GameDto>>();
            CreateMap<Maybe<Game>, Maybe<GameDto>>();
            CreateMap<Maybe<List<Game>>, Maybe<List<GameDto>>>();

            CreateMap<Price, PriceDto>();
            CreateMap<PriceDto, Price>();
            CreateMap<PagedList<Price>, PagedList<PriceDto>>();
            CreateMap<Maybe<Price>, Maybe<PriceDto>>();
            CreateMap<Maybe<List<Price>>, Maybe<List<PriceDto>>>();

            CreateMap<Seat, SeatDto>();
            CreateMap<SeatDto, Seat>();
            CreateMap<PagedList<Seat>, PagedList<SeatDto>>();
            CreateMap<Maybe<Seat>, Maybe<SeatDto>>();
            CreateMap<Maybe<List<Seat>>, Maybe<List<SeatDto>>>();

            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItemDto, MenuItem>();
            CreateMap<PagedList<MenuItem>, PagedList<MenuItemDto>>();
            CreateMap<Maybe<MenuItem>, Maybe<MenuItemDto>>();
            CreateMap<Maybe<List<MenuItem>>, Maybe<List<MenuItemDto>>>();

            CreateMap<Pc, PcDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Hdd, opt => opt.MapFrom(src => src.Hdd))
                .ForMember(dst => dst.Ssd, opt => opt.MapFrom(src => src.Ssd))
                .ForMember(dst => dst.Ram, opt => opt.MapFrom(src => src.Ram))
                .ForMember(dst => dst.Cpu, opt => opt.MapFrom(src => src.Cpu))
                .ForMember(dst => dst.Gpu, opt => opt.MapFrom(src => src.Gpu));
            CreateMap<PcDto, Pc>();
            CreateMap<PagedList<Pc>, PagedList<PcDto>>();
            CreateMap<Maybe<Pc>, Maybe<PcDto>>();
            CreateMap<Maybe<List<Pc>>, Maybe<List<PcDto>>>();

            CreateMap<Periphery, PeripheryDto>();
            CreateMap<PagedList<Periphery>, PagedList<PeripheryDto>>();
            CreateMap<Maybe<Periphery>, Maybe<PeripheryDto>>();
            CreateMap<Maybe<List<Periphery>>, Maybe<List<PeripheryDto>>>();

            CreateMap<GameConsole, GameConsoleDto>();
            CreateMap<PagedList<GameConsole>, PagedList<GameConsoleDto>>();
            CreateMap<Maybe<GameConsole>, Maybe<GameConsoleDto>>();
            CreateMap<Maybe<List<GameConsole>>, Maybe<List<GameConsoleDto>>>();

            CreateMap<UserRefreshToken, UserRefreshTokenDto>();
            CreateMap<Maybe<UserRefreshToken>, Maybe<UserRefreshTokenDto>>();

            CreateMap<AuthorizationRequest, ApiUser>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<ApiUser, ApiUserDto>();
            CreateMap<ApiUserDto, ApiUser>();
            CreateMap<Maybe<ApiUser>, Maybe<ApiUserDto>>();

            //.ForMember(dst => dst.User, opt => opt.MapFrom(src => src.User))
            //.ForMember(dst => dst.Begining, opt => opt.MapFrom(src => src.Begining))
            //.ForMember(dst => dst.Ending, opt => opt.MapFrom(src => src.Ending))
            //.ForMember(dst => dst.Tariff, opt => opt.MapFrom(src => src.Tariff))
            //.ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats));
          
                //.ForMember(dst=>dst.User,opt=>opt.MapFrom(src=>src.User))
                //.ForMember(dst => dst.Begining, opt => opt.MapFrom(src => src.Begining))
                //.ForMember(dst => dst.Ending, opt => opt.MapFrom(src => src.Ending))
                //.ForMember(dst => dst.Tariff, opt => opt.MapFrom(src => src.Tariff))
                //.ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats));

         

            CreateMap<Room, RoomDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dst => dst.Pc, opt => opt.MapFrom(src => src.Pc))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.Prices, opt => opt.MapFrom(src => src.Prices))
                .ForMember(dst => dst.Consoles, opt => opt.MapFrom(src => src.Consoles))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            CreateMap<PagedList<Room>, PagedList<RoomDto>>();
            CreateMap<RoomDto, Room>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dst => dst.Pc, opt => opt.MapFrom(src => src.Pc))
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.Prices, opt => opt.MapFrom(src => src.Prices))
                .ForMember(dst => dst.Consoles, opt => opt.MapFrom(src => src.Consoles))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            CreateMap<Maybe<Room>, Maybe<RoomDto>>();
            CreateMap<PagedList<Room>, PagedList<RoomDto>>();
            CreateMap<PagedList<RoomDto>, PagedList<Room>>();

            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();
            CreateMap<Maybe<Booking>, Maybe<BookingDto>>();
            CreateMap<PagedList<Booking>, PagedList<BookingDto>>();

            CreateMap<BookingCreateRequest, Booking>()
                .ForMember(dst => dst.User,opt=>opt.MapFrom(src=>src.User))
                .ForMember(dst=>dst.Room, opt=>opt.MapFrom(src=>src.Room))
                .ForMember(dst => dst.Begining, opt => opt.MapFrom(src => src.Begining))
                .ForMember(dst => dst.Ending, opt => opt.MapFrom(src => src.Ending))
                .ForMember(dst => dst.Tariff, opt => opt.MapFrom(src => src.Tariff))
                .ForMember(dst=>dst.User,opt=>opt.MapFrom(src=>src.User))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats.Select(item=> new SeatDto { Number = item, IsFree = false})));

            //CreateMap<Maybe<List<Room>>, Maybe<List<RoomDto>>>();
        }
    }
}
