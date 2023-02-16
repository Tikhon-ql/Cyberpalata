using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository repository, ITeamRepository teamRepository, IMapper mapper)
        {
            _tournamentRepository = repository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var tournamentDto = _mapper.Map<TournamentDto>(viewModel);
            var id = await _tournamentRepository.CreateAsync(_mapper.Map<Tournament>(tournamentDto));
            return id;
        }

        public async Task<List<GetTournamentViewModel>> GetActualTournaments()
        {
            var tournaments = _tournamentRepository.GetAll();
            var actualTournaments = tournaments.Where(t=>t.Date > DateTime.UtcNow);
            return _mapper.Map<List<GetTournamentViewModel>>(actualTournaments);
        }

        public async Task<Result> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var team = await _teamRepository.ReadAsync(viewModel.TeamId);
            if (team.HasNoValue)
                return Result.Failure("Team with sended id doesn't exist");
            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure("Tournament with sended id doesn't exist");

            tournament.Value.Teams.Add(team.Value);
            return Result.Success();
        }
    }
}
