using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITeamService
    {
        Task CreateAsync(CreateTeamViewModel request);
        Task<PagedList<TeamDto>> GetPagedList(TeamFilterBL filter);
        Task<Maybe<TeamDetailViewModel>> GetTeamDetailed(Guid teamId);
        Task SetHiringState(Guid teamId,bool state);
        Task<Result<TeamDetailViewModel>> GetTeamInTournament(Guid teamId, Guid tournamentId);
    }
}
