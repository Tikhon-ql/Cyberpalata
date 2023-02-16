using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.Logic.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal class TeamMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Team, TeamDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Tournaments, opt => opt.MapFrom(src => src.Tournaments))
                .ForMember(dst => dst.Members, opt => opt.MapFrom(src => src.Members));
            profile.CreateMap<PagedList<Team>,PagedList<TeamDto>>();
            profile.CreateMap<TeamDto, Team>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Tournaments, opt => opt.MapFrom(src => src.Tournaments))
                .ForMember(dst => dst.Members, opt => opt.MapFrom(src => src.Members));
            profile.CreateMap<CreateTeamViewModel,TeamDto>();
            profile.CreateMap<Team, TeamDetailViewModel>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Members, 
                opt => opt.MapFrom(src => src.Members.Select(s => $"{s.Member.Username} {s.Member.Surname}")));
        }
    }
}
