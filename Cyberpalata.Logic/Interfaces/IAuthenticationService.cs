using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<ApiUserDto>> ValidateUserAsync(AuthenticateRequest request);
        Task<Token> GenerateTokenAsync(ApiUserDto user);
        string GenerateAccessToken(ApiUserDto user);
    }
}
