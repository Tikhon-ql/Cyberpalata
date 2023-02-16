using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.WebApi.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

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
        [Authorize]
        [HttpPut("registerTeam")]
        public async Task<IActionResult> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var result = await _tournamentService.RegisterTeam(viewModel);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }
        [Authorize]
        [HttpGet("getActualTournaments")]
        public async Task<IActionResult> GetActualTournaments()
        {
            var viewModel = await _tournamentService.GetActualTournaments();
            return await ReturnSuccess(viewModel);
        }
    }
}
