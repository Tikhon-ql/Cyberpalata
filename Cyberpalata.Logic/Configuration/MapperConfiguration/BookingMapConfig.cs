using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.ViewModel.Request.Booking;

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

            profile.CreateMap<BookingCreateViewModel, BookingDto>()
                .ForMember(dst=>dst.Date, opt=>opt.MapFrom(src=>src.Date))
                .ForMember(dst => dst.Begining, opt => opt.MapFrom(src => src.Begining))
                .ForMember(dst => dst.HoursCount, opt => opt.MapFrom(src => src.HoursCount))
                .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dst => dst.Seats, opt => opt.MapFrom(src => src.Seats.Select(item => new SeatDto { Number = item })));
        }
    }
}
