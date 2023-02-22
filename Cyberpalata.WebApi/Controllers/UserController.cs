using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Identities;
using Cyberpalata.ViewModel.Request.Identity;
using Cyberpalata.ViewModel.Response;
using Cyberpalata.ViewModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ITournamentService _tournamentService;

        public UserController(IUserService userService, IUnitOfWork uinOfWork, ITournamentService tournamentService) : base(uinOfWork)
        {
            _userService = userService;
            _tournamentService = tournamentService;
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

        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> GetActualTournamentsUsersTeamIsRegistered()
        //{

        //}

        //[Authorize]
        //[HttpGet("getUsersQrCode")]
        //public async Task<IActionResult> GetUsersQrCodes(Guid tournamentId)
        //{
        //    var userId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid).Value);

        //    var filter = new TeamQrCodeFilterBL
        //    {
        //        CaptainId = userId,
        //        CurrentPage = 1,
        //        PageSize = 10
        //    };
        //    var list = await _teamRegistrationQrCodeService.GetPagedListAsync(filter);

        //    var viewModel = new List<QrCodeViewModel>();
        //    foreach (var item in list.Items)
        //    {
        //        var qrCode = new QrCodeViewModel
        //        {
        //            Date = item.Date,
        //            Team = item.Team.Name,
        //            Tournament = item.Tournament.Name,
        //            QrCode = File(item.BitmapBytes, "image/bmp")
        //        };
        //        //using(var stream = new MemoryStream(item.BitmapBytes))
        //        //{
        //        //    qrCode.QrCode = Image.FromStream(stream);
        //        //}
        //        viewModel.Add(qrCode);
        //    }
        //    return Ok(viewModel);
        //}
    }
}
