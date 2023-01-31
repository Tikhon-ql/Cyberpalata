using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class UserRefreshTokenMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<UserRefreshToken, UserRefreshTokenDto>();
            profile.CreateMap<Maybe<UserRefreshToken>, Maybe<UserRefreshTokenDto>>();
        }
    }
}
