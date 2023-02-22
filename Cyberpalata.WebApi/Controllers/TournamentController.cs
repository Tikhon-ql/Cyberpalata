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
    [Route("/tournaments")]
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService,IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _tournamentService = tournamentService;
        }

        [Authorize]
        [HttpPost("createTournament")]
        public async Task<IActionResult> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var id = _tournamentService.CreateTournament(viewModel);
            return await ReturnSuccess();
        }
        //[Authorize]
        [HttpPut("registerTeam")]
        public async Task<IActionResult> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var result = await _tournamentService.RegisterTeam(viewModel);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess(result.Value);
        }
        [Authorize]
        [HttpGet("getActualTournaments")]
        public async Task<IActionResult> GetActualTournaments()
        {

            var filter = new TournamentFilterBL
            {
                IsActual = true,
                CurrentPage = 1,
                PageSize = 10   
            };
            var result = await _tournamentService.GetPagedList(filter);
            var viewModel = new List<GetTournamentViewModel>();
            foreach (var item in result.Items) 
            {
                viewModel.Add(new GetTournamentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return await ReturnSuccess(viewModel);
        }
        //[Authorize]
        [HttpGet("getTournamentDetaile")]
        public async Task<IActionResult> GetTournamentDetaile(Guid tournamentId)
        {
            var viewModel = await _tournamentService.GetTournamentDetailed(tournamentId);
            return await ReturnSuccess(viewModel);
        }

        [HttpGet("getUsersTournaments")]
        public async Task<IActionResult> GetActualTournamentsUsersTeamIsRegistered()
        {
            var userId = Guid.Parse(User.Claims.First(c=>c.Type == JwtRegisteredClaimNames.Sid).Value);

            var filter = new TournamentFilterBL
            {
                CaptainId = userId,
                IsActual = true,
                CurrentPage = 1,
                PageSize = 10
            };
            var result = await _tournamentService.GetPagedList(filter);
            var viewModel = new List<UserTournamentViewModel>();
            foreach (var item in result.Items)
            {
                var teamInTournament = item.Teams.FirstOrDefault(t=> t.Captain.Member.Id == userId);
                viewModel.Add(new UserTournamentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    TeamId = teamInTournament.Id,
                });
            }
            return Ok(viewModel);
        }
    }
}
