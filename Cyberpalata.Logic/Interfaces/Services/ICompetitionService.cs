using CSharpFunctionalExtensions;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITournamentService
    {
        Task<Guid> CreateTournament(CreateTournamentViewModel viewModel);
        Task<Result> RegisterTeam(RegisterTeamViewModel viewModel);
        Task<List<GetTournamentViewModel>> GetActualTournaments();
    }
}
