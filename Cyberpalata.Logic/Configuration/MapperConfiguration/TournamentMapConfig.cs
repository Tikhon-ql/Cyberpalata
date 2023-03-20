using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal class TournamentMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Tournament, TournamentDto>()
                .ForMember(dst => dst.RoundCount, opt => opt.MapFrom(src => src.RoundsCount))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst => dst.Winner, opt => opt.MapFrom(src => src.Winner))
                .ForMember(dst => dst.Begining, opt => opt.MapFrom(src => TimeSpan.Parse($"{src.Date.Hour}:{src.Date.Minute}")))
                .ForMember(dst => dst.Batles, opt => opt.MapFrom(src => src.Batles))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<TournamentDto, Tournament>()
                .ForMember(dst => dst.RoundsCount, opt => opt.MapFrom(src => src.RoundCount))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date.Add(src.Begining)))
                .ForMember(dst => dst.Winner, opt => opt.MapFrom(src => src.Winner))
                .ForMember(dst => dst.Batles, opt => opt.MapFrom(src => src.Batles))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<CreateTournamentViewModel, TournamentDto>();
            profile.CreateMap<Tournament, GetTournamentViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<PagedList<Tournament>, PagedList<TournamentDto>>();
        }
    }
}
