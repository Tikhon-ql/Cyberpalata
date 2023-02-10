using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Identity;
using Cyberpalata.Logic.Models.Identity.User;
using Cyberpalata.ViewModel.User;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class ApiUserController : BaseController
    {
        private readonly IApiUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly ISeatService _seatService;
        private readonly ILogger<ApiUserController> _logger;

        public ApiUserController(IApiUserService userService, 
            ILogger<ApiUserController> logger,
            IBookingService bookingService, 
            IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _bookingService = bookingService;
            _logger = logger;
        }

        //create bad request json
        [HttpPost("register")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> Registration(UserCreateRequest request)
        {
            var result = await _userService.CreateAsync(request);
            if (result.IsFailure)
            {
                return BadRequestJson(result);
            }
            return await ReturnSuccess();
        }

        [HttpGet("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering([EmailAddress]string email)
        {
            await _userService.PasswordRecoveryAsync(email);
            return Ok();
        }

        [HttpPut("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering(PasswordResetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState.ToString()}");
            }
            var result = await _userService.ResetPasswordAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [HttpPost("emailConfirm")]
        public async Task<IActionResult> EmailConfrim([EmailAddress]string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState}");
            }
            int code = _userService.SendCodeToMail(email);
            return Ok(code);
        }

        [HttpPost("activate")]
        public async Task<IActionResult> ActivateUser([EmailAddress]string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest($"Bad request: {ModelState}");
            }
            var result = await _userService.ActivateUser(email);
            if(result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }
    }
}
