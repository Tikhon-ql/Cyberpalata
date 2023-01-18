﻿using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Result<ApiUserDto>> ValidateUserAsync(Maybe<AuthenticateRequest> request);
        Task<Maybe<TokenDto>> GenerateTokenAsync(ApiUserDto user);
        Task<Result<TokenDto>> RefreshTokenAsync(Maybe<TokenDto> tokenDto);
        Task<Result> LogoutAsync(Maybe<TokenDto> tokenDto);
    }
}
