using Azure.Core;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Configuration
{
    public static class ApiUserMapper
    {

        public static ApiUser MapFromDto(ApiUserDto dto)
        {
            return new ApiUser
            {
                Username = dto.Username,
                Surname = dto.Surname,
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone
            };
        }

        public static ApiUser MapToApiUser(AuthorizationRequest request)
        {
            return new ApiUser
            {
                Username = request.Username,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                Phone = request.Phone
            };
        }
    }
}
