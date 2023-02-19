using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal class TournamentMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Tournament, TournamentDto>();
            profile.CreateMap<TournamentDto, Tournament>()
                .ForMember(dst => dst.TeamsMaxCount, opt => opt.MapFrom(src => src.TeamsMaxCount))
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dst=>dst.Winner, opt=>opt.MapFrom(src=>src.Winner))
                .ForMember(dst=>dst.Teams, opt=>opt.MapFrom(src=>src.Teams))
                .ForMember(dst=>dst.Prizes, opt=>opt.MapFrom(src=>src.Prizes))
                .ForMember(dst=>dst.Rounds, opt=>opt.MapFrom(src=>src.Rounds))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
            profile.CreateMap<CreateTournamentViewModel, TournamentDto>();
            profile.CreateMap<Tournament, GetTournamentViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
