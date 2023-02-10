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
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> PasswordRecovering(PasswordResetRequest request)
        {
            var result = await _userService.ResetPasswordAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpPut("editUser")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> EditUser(UserUpdateRequest request)
        {
            request.UserId = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            await _userService.UpdateUserAsync(request);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getUserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var id = Guid.Parse(User.Claims.Single(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value.ToString());
            var user = await _userService.ReadAsync(id);
            return Ok(new ProfileViewModel
            {
                Username = user.Value.Username,
                Surname = user.Value.Surname,
                Email = user.Value.Email,
                Phone = user.Value.Phone,
            });
        }


        [HttpPost("emailConfirm")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> EmailConfrim([FromBody]EmailConfirmRequest request)
        {
            int code = _userService.SendCodeToMail(request.Email);
            return Ok(code);
        }

        [HttpPut("activate")]
        [ServiceFilter(typeof(ModelStateValidationFilter))]
        public async Task<IActionResult> ActivateUser([FromBody]ActivateUserRequest request)
        {
            var result = await _userService.ActivateUser(request.Email);
            if(result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }
    }
}
