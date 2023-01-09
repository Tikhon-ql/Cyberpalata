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

        //[HttpGet]
        //public async Task<IActionResult> Get(string userName, string password)
        //{ 
        //    await _userService.LoginAsync(userName, password,false);
        //    Console.WriteLine(User.Identity.Name);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]AuthorizationRequest request)
        {
            var result = await _userService.CreateAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm]AuthenticateRequest request)
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

        [HttpGet("refresh")]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
        {
            //Add result 
            // _authService.RefreshToken();
            //var res = await _authenticationService.RefreshTokenAsync(refreshToken,new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            //if (res.IsFailure)
            //    return BadRequest(res.Error);
            //return await ReturnSuccess(res.Value);
            return await ReturnSuccess("Good");
        }
    }
}
