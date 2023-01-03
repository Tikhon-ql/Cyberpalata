using AutoMapper;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration
{
    internal static class ApiUserMapper 
    {
        public static ApiUser MapFromDto(ApiUserDto userDto)
        {
            return new ApiUser { UserName = userDto.Email };
        }
        public static ApiUserDto MapToDto(ApiUser user)
        {
            return new ApiUserDto { Email = user.UserName };
        }
    }
}
