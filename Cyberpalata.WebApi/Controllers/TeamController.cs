using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/teams")]
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _teamService = teamService;
        }


        [Authorize]
        [HttpPost("createTeam")]
        public async Task<IActionResult> CreateTeam(CreateTeamViewModel viewModel)
        {
            var id = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            viewModel.CaptainId = id;
            await _teamService.CreateAsync(viewModel);
            return await ReturnSuccess();
        }

        [HttpGet("getTeam")]
        public async Task<IActionResult> GetTeam(Guid teamId)
        {
            var viewModel = await _teamService.GetTeamDetailed(teamId);
            if (viewModel.HasNoValue)
                return BadRequest(viewModel);
            return await ReturnSuccess(viewModel.Value);
        }

        [HttpGet("getTeamInTournament")]
        public async Task<IActionResult> GetTeamInTournament(Guid teamId, Guid tournamentId)
        {
            var viewModelResult = await _teamService.GetTeamInTournament(teamId, tournamentId);
            if (viewModelResult.IsFailure)
                return BadRequestJson(viewModelResult);
            return await ReturnSuccess(viewModelResult.Value);
        }


        [HttpPut]
        public async Task<IActionResult> SetTeamHiringState(Guid teamId)
        {
            await _teamService.SetHiringState(teamId, true);
            return await ReturnSuccess();
        }

        [HttpGet("getHiringTeams")]
        public async Task<IActionResult> GetHiringTeams(int page)
        {
            var teamFilter = new TeamFilterBL
            {
                CurrentPage = page,
                PageSize = 5,
                IsHiring = true,
            };

            var result = await _teamService.GetPagedList(teamFilter);
            var viewModel = new List<HiringTeamViewModel>();
            foreach (var team in result.Items)
            {
                viewModel.Add(new HiringTeamViewModel
                {
                    Id = team.Id,
                    Name = team.Name
                });
            }
            return Ok(new { Items = viewModel, PageSize = result.PageSize, TotalItemsCount = result.TotalItemsCount });
        }

        [Authorize]
        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetTeamsByUserId()
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            var filter = new TeamFilterBL
            {
                CurrentPage = 1,
                PageSize = 10,
                CaptainId = userId
            };
            var list = await _teamService.GetPagedList(filter);
            var viewModel = new List<GetTeamViewModel>();
            foreach (var team in list.Items)
            {
                viewModel.Add(new GetTeamViewModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    CaptainName = $"{team.Captain.Member.Username} {team.Captain.Member.Surname}"
                });
            }
            return await ReturnSuccess(viewModel);
        }

     
    }
}
