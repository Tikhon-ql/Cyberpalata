using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models.Room;

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
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            profile.CreateMap<PagedList<Room>, PagedList<RoomDto>>()
                .ForMember(dst => dst.Items, opt => opt.MapFrom(src => src.Items.AsEnumerable()))
                .ForMember(dst => dst.CurrentPageNumber, opt => opt.MapFrom(src => src.CurrentPageNumber))
                .ForMember(dst => dst.PageSize, opt => opt.MapFrom(src => src.PageSize))
                .ForMember(dst => dst.TotalItemsCount, opt => opt.MapFrom(src => src.TotalItemsCount));
            profile.CreateMap<RoomDto, Room>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dst => dst.Peripheries, opt => opt.MapFrom(src => src.Peripheries))
                .ForMember(dst => dst.IsVip, opt => opt.MapFrom(src => src.IsVip));
            profile.CreateMap<Maybe<Room>, Maybe<RoomDto>>();
            profile.CreateMap<PagedList<RoomDto>, PagedList<Room>>();
        }
    }
}
