using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
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
        Task<Maybe<TokenDto>> GenerateTokenAsync(ApiUserDto user);
        Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto);
        Task<Result> LogoutAsync(TokenDto tokenDto);
    }
}
