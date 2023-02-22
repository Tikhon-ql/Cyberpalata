using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITournamentService
    {
        Task<Guid> CreateTournament(CreateTournamentViewModel viewModel);
        Task<Result<TeamRegistrationViewModel>> RegisterTeam(RegisterTeamViewModel viewModel);
        //Task<List<GetTournamentViewModel>> GetActualTournaments();
        Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId);
        Task<PagedList<TournamentDto>> GetPagedList(TournamentFilterBL filter);
    }
}
