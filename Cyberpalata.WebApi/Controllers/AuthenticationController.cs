using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/authentication")]
    public class AuthenticationController : BaseController
    {
        private readonly IApiUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRefreshTokenService _refreshTokenService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IApiUserService userService, IAuthenticationService authenticationService, IUserRefreshTokenService refreshTokenService,ILogger<AuthenticationController> logger, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
            _logger = logger;
        }
        //User locates in token get id from accessToken
      

        [HttpPost("login")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> Login(AuthenticateRequest request)
        {
            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Validation error");
            //    return BadRequest($"Bad request: {ModelState}");
            //}

            var result = await _authenticationService.ValidateUserAsync(request);
            if (result.IsFailure)
            {
                return BadRequestJson(result);
            }

            var token = await _authenticationService.GenerateTokenAsync(result.Value);
            return await ReturnSuccess(token.Value);
        }

        [HttpPost("logout")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] TokenDto tokenDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest($"Bad request: {ModelState.ToString()}");
            //}
            var res = await _authenticationService.LogoutAsync(tokenDto);

            if (res.IsFailure)
            {
                if (res.Error == "")
                {
                    return await ReturnSuccess();
                }
                return BadRequest(res.Error);
            }
               

            return await ReturnSuccess();
        }
        //?????????? move to api user controller
        [AllowAnonymous]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest($"Bad request: {ModelState.ToString()}");
            //}
            var res = await _authenticationService.RefreshTokenAsync(tokenDto);

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess(res.Value);
        }
    }
}