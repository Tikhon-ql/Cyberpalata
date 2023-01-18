﻿using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Functional.Maybe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.ReadAsync(id);

            if (!user.HasValue)
                return BadRequest("User isn't exist");

            return Ok(user.Value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(AuthorizationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Bad request");
            }
            var result = await _userService.CreateAsync(request.ToMaybe());
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

            var result = await _authenticationService.ValidateUserAsync(request.ToMaybe());
            if (result.IsFailure)
                return BadRequest(result.Error);

            var token = await _authenticationService.GenerateTokenAsync(result.Value);

            
            return await ReturnSuccess(token.Value);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] TokenDto tokenDto)
        {
            var res = await _authenticationService.LogoutAsync(tokenDto.ToMaybe());

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess();
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenDto tokenDto)
        {
            var res = await _authenticationService.RefreshTokenAsync(tokenDto.ToMaybe());

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess(res.Value);
        }
    }
}