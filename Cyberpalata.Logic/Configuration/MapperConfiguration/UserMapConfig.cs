using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity.User;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class UserMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<UserCreateRequest, ApiUser>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));

            profile.CreateMap<ApiUser, ApiUserDto>();
            profile.CreateMap<ApiUserDto, ApiUser>();
            profile.CreateMap<Maybe<ApiUser>, Maybe<ApiUserDto>>();
        }
    }
}
