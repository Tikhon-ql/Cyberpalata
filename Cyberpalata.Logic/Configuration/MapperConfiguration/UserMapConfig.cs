﻿using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel.Request.Identity;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class UserMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<UserCreateViewModel, User>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password));

            profile.CreateMap<User, UserDto>();
                //.ForMember(dst => dst.Id, opt=>opt.MapFrom(src=>src.Id))
                //.ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Username))
                //.ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
                //.ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone))
                //.ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                //.ForMember(dst => dst.Teams, opt => opt.MapFrom(src => src.Teams))
                //.ForMember(dst => dst.Bookings, opt => opt.MapFrom(src => src.Bookings));
            profile.CreateMap<UserDto, User>();
            profile.CreateMap<Maybe<User>, Maybe<UserDto>>();
        }
    }
}
