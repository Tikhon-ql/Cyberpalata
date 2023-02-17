using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Seats;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class BatleMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Batle, BatleDto>();
        }
    }
}
