using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Filters;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/tournaments")]
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;
        private readonly ITeamService _teamService;
        public TournamentController(ITournamentService tournamentService, ITeamService teamService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _tournamentService = tournamentService;
            _teamService = teamService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("createTournament")]
        public async Task<IActionResult> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var result = await _tournamentService.CreateTournament(viewModel);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }
        [Authorize]
        [HttpPut("registerTeam")]
        public async Task<IActionResult> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _tournamentService.RegisterTeam(viewModel, userId);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess(result.Value);
        }

        private async Task<bool> IsCaptain(Guid userId)
        {
            if (userId == Guid.Empty)
                return false;
            var teamFilter = new TeamFilterBL()
            {
                MemberId = userId,
                PageSize = 1,
                CurrentPage = 1
            };

            var team = await _teamService.GetPagedList(teamFilter);

            if (team.Items.Count != 0)
            {
                return team.Items.ElementAt(0).Captain.Member.Id == userId;
            };
            return false;
        }

        [HttpPost("getTournaments")]
        public async Task<IActionResult> GetTournaments([FromBody] TournamentFilterViewModel filterViewModel)
        {
            var claim = User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sid);
            var userId = claim != null ? Guid.Parse(claim.Value) : Guid.Empty;
            var filter = new TournamentFilterBL
            {
                SearchName = filterViewModel.SearchName,
                IsActual = filterViewModel.ActualTournaments ? true
                           : filterViewModel.AllTournaments ? Maybe.None : false,
                CurrentPage = filterViewModel.Page,
                PageSize = 5
            };
            var result = await _tournamentService.GetPagedList(filter);
            var viewModel = new List<GetTournamentViewModel>();
            foreach (var item in result.Items)
            {
                viewModel.Add(new GetTournamentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    TeamsCount = item.TeamsCount,
                    Date = item.Date.ToString("d"),
                    Begining = item.Begining.ToString(),
                });
            }

            return Ok(new { PageSize = result.PageSize, TotalItemsCount = result.TotalItemsCount, Items = viewModel, IsCaptain = await IsCaptain(userId) });
        }
        [HttpGet("getTournamentDetaile")]
        public async Task<IActionResult> GetTournamentDetaile(Guid tournamentId)
        {
            var viewModel = await _tournamentService.GetTournamentDetailed(tournamentId);
            return await ReturnSuccess(viewModel);
        }
        [HttpGet("getTournamentSmall")]
        public async Task<IActionResult> GetTournamentSmall(Guid id)
        {
            var viewModel = await _tournamentService.GetTournamentSmall(id);
            return Ok(viewModel);
        }

        [Authorize]
        [HttpGet("getUsersTournaments")]
        public async Task<IActionResult> GetActualTournamentsUsersTeamIsRegistered(int page)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);

            var filter = new TournamentFilterBL
            {
                CaptainId = userId,
                IsActual = true,
                CurrentPage = page,
                PageSize = 3
            };
            var result = await _tournamentService.GetPagedList(filter);
            var viewModel = new List<UserTournamentViewModel>();
            foreach (var item in result.Items)
            {
                var teamInTournament = item.Batles.FirstOrDefault(t => t.FirstTeam.Captain.Member.Id == userId).FirstTeam;
                if (teamInTournament == null)
                    teamInTournament = item.Batles.FirstOrDefault(t => t.FirstTeam.Captain.Member.Id == userId).SecondTeam;
                viewModel.Add(new UserTournamentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    TeamId = teamInTournament.Id,
                });
            }
            return Ok(new { PageSize = result.PageSize, TotalItemsCount = result.TotalItemsCount, Items = viewModel });
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("approveTeam")]
        public async Task<IActionResult> ApproveTeam(Guid teamId, Guid tournamentId)
        {
            var result = await _tournamentService.ApproveTeam(teamId, tournamentId);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }
    }
}
