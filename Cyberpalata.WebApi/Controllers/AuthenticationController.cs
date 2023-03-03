using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel;
using Cyberpalata.ViewModel.Request.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _authenticationService = authenticationService;
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