using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Identities;
using Cyberpalata.ViewModel.Request.Identity;
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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registration(UserCreateViewModel request)
        {
            var result = await _userService.CreateAsync(request);
            if (result.IsFailure)
            {
                return BadRequestJson(result);
            }
            return await ReturnSuccess(result.Value);
        }

        [HttpGet("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering(PasswordRecoveringViewModel viewModel)
        {
            await _userService.PasswordRecoveryAsync(viewModel.Email);
            return Ok();
        }

        [HttpPut("passwordRecovering")]
        public async Task<IActionResult> PasswordRecovering(PasswordResetViewModel request)
        {
            var result = await _userService.ResetPasswordAsync(request);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpPut("editUser")]
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
        public async Task<IActionResult> EmailConfrim([FromBody]EmailConfirmViewModel viewModel)
        {
            var resultCode = await _userService.SendCodeToMailAsync(viewModel);
            if (resultCode.IsFailure)
                return BadRequest(resultCode);

            return Ok(resultCode.Value);
        }

        [HttpPut("activate")]
        public async Task<IActionResult> ActivateUser([FromBody]ActivateUserRequest request)
        {
            var result = await _userService.ActivateUser(request.Email);
            if(result.IsFailure)
                return BadRequest(result.Error);
            return await ReturnSuccess();
        }
    }
}
