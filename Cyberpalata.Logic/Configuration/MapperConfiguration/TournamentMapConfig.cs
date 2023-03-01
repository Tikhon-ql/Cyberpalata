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
            profile.CreateMap<Tournament, TournamentDto>();
            profile.CreateMap<TournamentDto, Tournament>()
                .ForMember(dst => dst.RoundsCount, opt => opt.MapFrom(src => src.RoundCount))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst=>dst.Winner, opt=>opt.MapFrom(src=>src.Winner))
                .ForMember(dst=>dst.Batles, opt=>opt.MapFrom(src=>src.Batles))
                .ForMember(dst=>dst.BatleResults, opt=>opt.MapFrom(src=>src.BatleResults))
                //.ForMember(dst=>dst.Teams, opt=>opt.MapFrom(src=>src.Teams))
                .ForMember(dst=>dst.Prizes, opt=>opt.MapFrom(src=>src.Prizes))
                //.ForMember(dst=>dst.Rounds, opt=>opt.MapFrom(src=>src.Rounds))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<CreateTournamentViewModel, TournamentDto>();
                //.ForMember(dst => dst.RoundCount, opt => opt.MapFrom(src => src.RoundCount))
                //.ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date));
            profile.CreateMap<Tournament, GetTournamentViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<PagedList<Tournament>, PagedList<TournamentDto>>();
        }
    }
}
