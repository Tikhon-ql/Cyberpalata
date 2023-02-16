using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Request.Identity;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRefreshTokenService _refreshTokenService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IUserService userService, IAuthenticationService authenticationService, IUserRefreshTokenService refreshTokenService,ILogger<AuthenticationController> logger, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateViewModel request)
        {
            var result = await _authenticationService.ValidateUserAsync(request);
            if (result.IsFailure)
            {
                return BadRequestJson(result);
            }

            var token = await _authenticationService.GenerateTokenAsync(result.Value);
            return await ReturnSuccess(token);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody]TokenViewModel tokenViewModel)
        {
            var res = await _authenticationService.LogoutAsync(tokenViewModel);

            if (res.IsFailure)
            {
                return BadRequestJson(res);
            }
               
            return await ReturnSuccess();
        }
        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenViewModel tokenDto)
        {
            var res = await _authenticationService.RefreshTokenAsync(tokenDto);

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess(res.Value);
        }
    }
}