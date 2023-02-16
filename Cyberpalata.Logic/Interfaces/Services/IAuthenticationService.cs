using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Request.Identity;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Result<UserDto>> ValidateUserAsync(AuthenticateViewModel request);
        Task<TokenViewModel> GenerateTokenAsync(UserDto user);
        Task<Result<TokenViewModel>> RefreshTokenAsync(TokenViewModel tokenDto);
        Task<Result> LogoutAsync(TokenViewModel tokenDto);
    }
}
