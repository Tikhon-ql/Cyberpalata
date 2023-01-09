﻿using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IUserRefreshTokenRepository
    {
        Task CreateAsync(UserRefreshToken entity);
        Task<UserRefreshToken> ReadAsync(string refreshToken);
        Task DeleteAsync(string refreshToken);
        Task<Result<ApiUser>> GetUserByRefreshToken(string refreshToken);
    }
}
