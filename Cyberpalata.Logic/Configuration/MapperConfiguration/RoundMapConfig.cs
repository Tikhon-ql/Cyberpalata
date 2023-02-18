using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Booking;
using Cyberpalata.ViewModel.Request.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class RoundMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Round, RoundDto>();
            profile.CreateMap<RoundCreateViewModel, RoundDto>();
        }
    }
}
