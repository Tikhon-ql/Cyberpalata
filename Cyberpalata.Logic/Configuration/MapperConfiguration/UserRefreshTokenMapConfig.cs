using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;

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
