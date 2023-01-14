using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Security.Claims;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class ApiUserController : BaseController
    {
        private readonly IApiUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRefreshTokenService _refreshTokenService;

        public ApiUserController(IApiUserService userService,IAuthenticationService authenticationService,IUserRefreshTokenService refreshTokenService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.ReadAsync(id);
            return await ReturnSuccess(user.Value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(AuthorizationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }
            var result = await _userService.CreateAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }
            var result = await _authenticationService.ValidateUserAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = await _authenticationService.GenerateTokenAsync(result.Value);

            return await ReturnSuccess(token);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] TokenDto tokenDto)
        {
            var res = await _authenticationService.LogoutAsync(tokenDto);
            if (res.IsFailure) return BadRequest(res.Error);
            return await ReturnSuccess();
        }



        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenDto tokenDto)
        {
            ////Add result 
            /////send accessToken
            var res = await _authenticationService.RefreshTokenAsync(tokenDto);
            if (res.IsFailure)
                return BadRequest(res.Error);
            return await ReturnSuccess(res.Value);
        }
    }
}
 