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

        public async Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId)
        {
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);
            //if (tournament.HasNoValue)
            //    return ; // ??? что делать в таких ситуациях ? Exception
            var viewModel = new TournamentDetailedViewModel
            {
                Name = tournament.Value.Name,
                Date = tournament.Value.Date.ToString("d"),
                TeamsMaxCount = tournament.Value.TeamsMaxCount,
                Rounds = new List<RoundViewModel>()
                //Batles = new List<TeamBatleViewModel>()
            };
            int roundMaxCount = GetRoundMaxCount(tournament.Value.TeamsMaxCount);

            int index = 0;
            foreach(var round in tournament.Value.Rounds)
            {
                var roundViewModel = new RoundViewModel();
                int roundBatlesMaxCount = CalculateRoundTeamsMaxCount(tournament.Value.TeamsMaxCount, index) / 2;
                foreach(var batle in round.Batles)
                {
                    roundViewModel.Batles.Add(new TeamBatleViewModel
                    {
                        Date = batle.Date.ToString("d"),
                        FirstTeamName = batle.FirstTeam.Name,
                        SecondTeamName = batle.SecondTeam.Name,
                        FirstTeamScore = batle.FirstTeamScore,
                        SecondTeamScore = batle.SecondTeamScore
                    });
                }
                for(int i = roundViewModel.Batles.Count - 1; i < roundBatlesMaxCount;i++)
                {
                    roundViewModel.Batles.Add(new TeamBatleViewModel
                    {
                        Date = "",
                        FirstTeamName = "",
                        SecondTeamName = "",
                        FirstTeamScore = 0,
                        SecondTeamScore = 0
                    });
                }
                index++;
                viewModel.Rounds.Add(roundViewModel);
            }

            //for(int i = 1;i < tournament.Value.Teams.Count;i+=2)
            //{
            //    viewModel.Batles.Add(new TeamBatleViewModel
            //    {
            //        FirstTeamName = tournament.Value.Teams[i - 1].Name,
            //        SecondTeamName = tournament.Value.Teams[i].Name,
            //        FirstTeamScore = 0,
            //        SecondTeamScore = 0,
            //    });
            //}
            //for(int i = viewModel.Batles.Count;i < viewModel.TeamsMaxCount - 1;i+=2)
            //{
            //    viewModel.Batles.Add(new TeamBatleViewModel
            //    {
            //        FirstTeamName = "Navi",
            //        SecondTeamName = "Vp",
            //        FirstTeamScore = 1,
            //        SecondTeamScore = 10,
            //    });
            //}
            return viewModel;
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

        private int GetRoundMaxCount(int teamMaxCount)
        {
            int roundMaxCount = 0;
            while (teamMaxCount > 0)
            {
                teamMaxCount /= 2;
                roundMaxCount++;
            }
            roundMaxCount--;
            return roundMaxCount;
        }

        private int CalculateRoundTeamsMaxCount(int teamMaxCount, int roundNumber)
        {
            while(roundNumber >= 0)
            {
                teamMaxCount /= 2;
                roundNumber--;
            }
            return teamMaxCount;
        }
    }
}
