using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Identities;
using Cyberpalata.ViewModel.Request.Identity;
using Cyberpalata.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITeamService _teamService;

        public UserController(IUserService userService,ITeamService teamService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _userService = userService;
            _teamService = teamService;
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

            var profile = new ProfileViewModel
            {
                Username = user.Value.Username,
                Surname = user.Value.Surname,
                Email = user.Value.Email,
                Phone = user.Value.Phone,
                HasTeam = false,
                IsCaptain = false
            };

            var filter = new TeamFilterBL
            {
                MemberId = id,
                CurrentPage = 1,
                PageSize = 1,
            };
            var team = await _teamService.GetPagedList(filter);
            if(team.Items.Count != 0)
            {
                profile.HasTeam = true;
                profile.IsCaptain = team.Items.ElementAt(0).Captain.Member.Id == id;
            };
            return Ok(profile);
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
