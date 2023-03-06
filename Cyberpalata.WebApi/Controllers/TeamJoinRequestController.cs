using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/joinRequests")]
    public class TeamJoinRequestController : BaseController
    {
        private readonly ITeamJoinRequestService _teamJoinRequestService;
        private readonly ITeamService _teamService;
        private readonly ILogger<TeamJoinRequestController> _logger;

        public TeamJoinRequestController(IUnitOfWork uinOfWork, ITeamJoinRequestService teamJoinRequestService, ITeamService teamService,ILogger<TeamJoinRequestController> logger) : base(uinOfWork)
        {
            _teamJoinRequestService = teamJoinRequestService;
            _teamService = teamService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("createJoinRequest")]
        public async Task<IActionResult> CreateJoinRequest(Guid teamId)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _teamJoinRequestService.CreateJoinRequest(teamId, userId);

            if (result.IsFailure)
                return BadRequestJson(result);

            return await ReturnSuccess();
        }

        [Authorize]
        [HttpPut("acceptJoinRequest")]
        public async Task<IActionResult> AcceptJoinRequest(JoinRequestStateSettingViewModel viewModel)
        {
            var result = await _teamJoinRequestService.SetJoinRequestState(viewModel,JoinRequestState.Accepted);
            if(result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getTeamJoinRequests")]
        public async Task<IActionResult> GetJoinRequests()
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var teamFilter = new TeamFilterBL
            {
                CurrentPage = 1,
                PageSize = 1,
                CaptainId = userId,
            };
            var team = await _teamService.GetPagedList(teamFilter);
            var teamJoinFilter = new TeamJoinRequestFilterBL
            {
                CurrentPage = 1,
                PageSize = 1,
                TeamId = team.Items.ElementAt(0).Id,
                State = JoinRequestState.None
            };

            var requests = await _teamJoinRequestService.GetPagedList(teamJoinFilter);

            var viewModel = new List<TeamJoinRequestViewModel>();
            foreach (var item in requests.Items)
            {
                viewModel.Add(new TeamJoinRequestViewModel
                {
                    UserId = item.User.Id,
                    TeamId = item.Team.Id,
                    Username = item.User.Username,
                    Usersurname = item.User.Surname
                });
            }

            return Ok(viewModel);
        }
    }
}
