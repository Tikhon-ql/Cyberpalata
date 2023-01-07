using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

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
            await _userService.CreateAsync(request);
            return await ReturnSuccessAsync();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromForm]AuthenticateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("");
            }
            var result = await _authenticationService.ValidateUserAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = await _authenticationService.GenerateTokenAsync(result.Value);

            return await ReturnSuccessAsync(token);
        }

        [HttpPost("/refresh")]
        public async Task<IActionResult> RefreshToken([Required] string refreshToken)
        {
            var user = await _userService.GetByRefreshToken(refreshToken);
            UserRefreshTokenDto refToken = await _refreshTokenService.ReadAsync(user.Id);

            if(refToken.Expiration >= DateTime.Now)
                return await ReturnSuccessAsync(await _authenticationService.GenerateTokenAsync(user));
            else
            {
                return await ReturnSuccessAsync(new Token
                {
                    AccessToken = _authenticationService.GenerateAccessToken(user),
                    RefreshToken = refreshToken
                });
            }
        }
    }
}
