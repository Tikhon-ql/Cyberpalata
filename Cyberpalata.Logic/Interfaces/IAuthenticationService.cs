﻿using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.Logic.Models.Identity.User;

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
