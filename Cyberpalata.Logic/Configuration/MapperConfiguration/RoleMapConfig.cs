using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class RoleMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Role, RoleDto>();
        }
    }
}
