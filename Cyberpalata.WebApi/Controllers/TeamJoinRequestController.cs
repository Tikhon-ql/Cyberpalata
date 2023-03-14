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
        private readonly IChatService _chatService;
        private readonly ILogger<TeamJoinRequestController> _logger;

        public TeamJoinRequestController(IUnitOfWork uinOfWork, ITeamJoinRequestService teamJoinRequestService, ITeamService teamService,ILogger<TeamJoinRequestController> logger, IChatService chatService) : base(uinOfWork)
        {
            _teamJoinRequestService = teamJoinRequestService;
            _teamService = teamService;
            _logger = logger;
            _chatService = chatService;
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
        [HttpPut("inProgressJoinRequest")]
        public async Task<IActionResult> inProgressJoinRequest(JoinRequestStateSettingViewModel viewModel)
        {
            var result = await _teamJoinRequestService.SetJoinRequestState(viewModel,JoinRequestState.None, JoinRequestState.InProgress);
            if(result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpPut("answerJoinRequest")]
        public async Task<IActionResult> AnswerJoinRequest(AnswerJoinRequestViewModel viewModel)
        {
            var joinRequestViewModel = new JoinRequestStateSettingViewModel()
            {
                TeamId = viewModel.TeamId,
                UserToJoinId = viewModel.UserToJoinId
            };
            var joinRequestStateChangeResult = await _teamJoinRequestService.SetJoinRequestState(joinRequestViewModel,JoinRequestState.InProgress ,viewModel.IsAccepted ? JoinRequestState.Accepted : JoinRequestState.Rejected);
            if (joinRequestStateChangeResult.IsFailure)
                return BadRequestJson(joinRequestStateChangeResult);

            var addingUserToTeamResult = await _teamService.AddUserToTeam(viewModel.UserToJoinId, viewModel.TeamId);
            if(addingUserToTeamResult.IsFailure)
                return BadRequestJson(addingUserToTeamResult);

            var chatStateChangeResult = await _chatService.SetIsDeletedState(viewModel.ChatId, true);
            if (chatStateChangeResult.IsFailure)
                return BadRequestJson(chatStateChangeResult);

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
