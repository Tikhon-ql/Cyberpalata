using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class BatleService : IBatleService
    {
        private readonly IBatleRepository _batleRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;

        public BatleService(IBatleRepository batleRepository, ITournamentRepository tournamentRepository,ITeamRepository teamRepository)
        {
            _batleRepository = batleRepository;
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Result> SetWinner(SetWinnerViewModel viewModel)
        {
            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure($"Tournament with id: {viewModel.TournamentId} doesn't exist");
            var batle = await _batleRepository.ReadAsync(viewModel.BatleId);
            Console.WriteLine("anime");
            if(batle.HasNoValue)
                return Result.Failure($"Batle with id: {viewModel.TournamentId} doesn't exist");
            var winner = await _teamRepository.ReadAsync(viewModel.WinnerId);
            var batleResult = new BatleResult
            {
                Id = Guid.NewGuid(),
                Batle = batle.Value,
                Date = DateTime.UtcNow,
                RoundNumber = batle.Value.RoundNumber,
                Winner = winner.Value,
            };
            tournament.Value.BatleResults.Add(batleResult);
            var isFirstTeamSet = tournament.Value.Batles.Where(b=>b.RoundNumber == batle.Value.RoundNumber + 1).FirstOrDefault(b=>b.SecondTeam == null);
            if(isFirstTeamSet != null)
            {
                isFirstTeamSet.SecondTeam = winner.Value;
                isFirstTeamSet.Date = DateTime.UtcNow;
            }
            else
            {
                tournament.Value.Batles.Add(new Batle
                {
                    Id = Guid.NewGuid(),
                    FirstTeam = winner.Value,
                    Tournament = tournament.Value,
                    RoundNumber = batle.Value.RoundNumber + 1
                });
            }
            return Result.Success();
        }
    }
}
