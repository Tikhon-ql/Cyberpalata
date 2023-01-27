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

namespace Cyberpalata.Logic.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {


            CreateMap<Game, GameDto>();
            CreateMap<PagedList<Game>, PagedList<GameDto>>();
            CreateMap<Maybe<Game>, Maybe<GameDto>>();
            CreateMap<Maybe<List<Game>>, Maybe<List<GameDto>>>();
    
            CreateMap<Price, PriceDto>();
            CreateMap<PagedList<Price>, PagedList<PriceDto>>();
            CreateMap<Maybe<Price>, Maybe<PriceDto>>();
            CreateMap<Maybe<List<Price>>, Maybe<List<PriceDto>>>();

            CreateMap<Seat, SeatDto>();
            CreateMap<PagedList<Seat>, PagedList<SeatDto>>();
            CreateMap<Maybe<Seat>, Maybe<SeatDto>>();
            CreateMap<Maybe<List<Seat>>, Maybe<List<SeatDto>>>();

            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<PagedList<MenuItem>, PagedList<MenuItemDto>>();
            CreateMap<Maybe<MenuItem>, Maybe<MenuItemDto>>();
            CreateMap<Maybe<List<MenuItem>>, Maybe<List<MenuItemDto>>>();

            CreateMap<Pc, PcDto>();
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
            CreateMap<Maybe<ApiUser>,Maybe<ApiUserDto>>();

            CreateMap<Booking, BookingDto>();
            CreateMap<PagedList<Booking>,PagedList<BookingDto>>();

            CreateMap<Room, RoomDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dst => dst.Prices, opt => opt.MapFrom(src => src.Prices))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type));
            CreateMap<Maybe<Room>, Maybe<RoomDto>>()
                .ForMember(dst=>dst.Value, opt=> opt.MapFrom(src=>src.Value));
            CreateMap<PagedList<Room>, PagedList<RoomDto>>()
                .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dst => dst.CurrentPageNumber, opt => opt.MapFrom(src => src.CurrentPageNumber))
                .ForMember(dst => dst.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dst => dst.TotalItemsCount, opt => opt.MapFrom(src => src.TotalItemsCount))
                .ForMember(dst => dst.TotalPagesCount, opt => opt.MapFrom(src => src.TotalPagesCount));
            //CreateMap<Maybe<List<Room>>, Maybe<List<RoomDto>>>();
        }
    }
}
