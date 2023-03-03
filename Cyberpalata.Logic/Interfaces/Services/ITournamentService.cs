using CSharpFunctionalExtensions;
using Cyberpalata.Common;
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
        Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId);
        Task<TournamentSmalViewModel> GetTournamentSmall(Guid tournamentId);
        Task<PagedList<TournamentDto>> GetPagedList(TournamentFilterBL filter);
    }
}
