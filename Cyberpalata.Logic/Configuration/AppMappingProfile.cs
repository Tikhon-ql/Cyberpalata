using AutoMapper;
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
            CreateMap<Maybe<Game>,Maybe<GameDto>>();
            CreateMap<PagedList<Maybe<Game>>, PagedList<Maybe<GameDto>>>();

            CreateMap<Room, RoomDto>();
            CreateMap<PagedList<Room>, PagedList<RoomDto>>();
            CreateMap<Maybe<Room>, Maybe<RoomDto>>();
            CreateMap<PagedList<Maybe<Room>>, PagedList<Maybe<RoomDto>>>();

            CreateMap<Price, PriceDto>();
            CreateMap<PagedList<Price>, PagedList<PriceDto>>();
            CreateMap<Maybe<Price>, Maybe<PriceDto>>();
            CreateMap<PagedList<Maybe<Price>>, PagedList<Maybe<PriceDto>>>();

            CreateMap<Seat, SeatDto>();
            CreateMap<PagedList<Seat>, PagedList<SeatDto>>();
            CreateMap<Maybe<Seat>, Maybe<SeatDto>>();
            CreateMap<PagedList<Maybe<Seat>>, PagedList<Maybe<SeatDto>>>();

            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<PagedList<MenuItem>, PagedList<MenuItemDto>>();
            CreateMap<Maybe<MenuItem>, Maybe<MenuItemDto>>();
            CreateMap<PagedList<Maybe<MenuItem>>, PagedList<Maybe<MenuItemDto>>>();

            CreateMap<Pc, PcDto>();
            CreateMap<PagedList<Pc>, PagedList<PcDto>>();
            CreateMap<Maybe<Pc>, Maybe<PcDto>>();
            CreateMap<PagedList<Maybe<Pc>>, PagedList<Maybe<PcDto>>>();

            CreateMap<Periphery, PeripheryDto>();
            CreateMap<PagedList<Periphery>, PagedList<PeripheryDto>>();
            CreateMap<Maybe<Periphery>, Maybe<PeripheryDto>>();
            CreateMap<PagedList<Maybe<Periphery>>, PagedList<Maybe<PeripheryDto>>>();

            CreateMap<GameConsole, GameConsoleDto>();
            CreateMap<PagedList<GameConsole>, PagedList<GameConsoleDto>>();
            CreateMap<Maybe<GameConsole>, Maybe<GameConsoleDto>>();
            CreateMap<PagedList<Maybe<GameConsole>>, PagedList<Maybe<GameConsoleDto>>>();

            CreateMap<UserRefreshToken, UserRefreshTokenDto>();
            CreateMap<Maybe<UserRefreshToken>, Maybe<UserRefreshTokenDto>>();

            CreateMap<AuthorizationRequest, ApiUser>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}
