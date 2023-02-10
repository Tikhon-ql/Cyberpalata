using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Models.Seats;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class SeatMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Seat, SeatDto>();
            profile.CreateMap<SeatDto, Seat>();
            profile.CreateMap<PagedList<Seat>, PagedList<SeatDto>>();
            profile.CreateMap<Maybe<Seat>, Maybe<SeatDto>>();
            profile.CreateMap<Maybe<List<Seat>>, Maybe<List<SeatDto>>>();
        }
    }
}
