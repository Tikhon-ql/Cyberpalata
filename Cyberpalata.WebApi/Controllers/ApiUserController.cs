﻿using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
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
        private readonly ILoggerManager _logger;

        public ApiUserController(IApiUserService userService, IAuthenticationService authenticationService, IUserRefreshTokenService refreshTokenService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _refreshTokenService = refreshTokenService;

        }
        //User locates in token get id from accessToken
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = new Guid(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).ToString());
            var user = await _userService.ReadAsync(id);
            return Ok(user.Value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(AuthorizationRequest request)
        {
            if (!ModelState.IsValid)
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
                _logger.LogError("Validation error");
                return BadRequest($"Bad request {ModelState.ToString()}");
            }

            var result = await _authenticationService.ValidateUserAsync(request);
            if (result.IsFailure)
            {
                _logger.LogError(result.Error);
                return BadRequest(result.Error);
            }
               

            var token = await _authenticationService.GenerateTokenAsync(result.Value);
            return await ReturnSuccess(token.Value);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] TokenDto tokenDto)
        {
            var res = await _authenticationService.LogoutAsync(tokenDto);

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess();
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var res = await _authenticationService.RefreshTokenAsync(tokenDto);

            if (res.IsFailure)
                return BadRequest(res.Error);

            return await ReturnSuccess(res.Value);
        }
    }
}