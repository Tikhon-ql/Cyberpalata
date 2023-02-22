using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.Extensions.Configuration;

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

            int index = 0;
            foreach(var round in tournament.Value.Rounds)
            {
                var roundViewModel = new RoundViewModel
                {
                    Number = round.Number,
                    Batles = new List<TeamBatleViewModel>(),
                    BatlesMaxCount = tournament.Value.TeamsMaxCount / 4 - round.Number * 2,
                    Date = round.Date.ToString("d"),
                };
                roundViewModel.BatlesMaxCount = roundViewModel.BatlesMaxCount == 0 ? 1 : roundViewModel.BatlesMaxCount;
                foreach(var batle in round.Batles)
                {
                    roundViewModel.Batles.Add(new TeamBatleViewModel
                    {
                        Date = batle.Date.ToString("d"),
                        FirstTeamName = batle.FirstTeam.Name,
                        SecondTeamName = batle.SecondTeam != null ? batle.SecondTeam.Name : " ",
                        FirstTeamScore = batle.FirstTeamScore,
                        SecondTeamScore = batle.SecondTeamScore,
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
            viewModel.Rounds.Sort((a,b)=>a.Number - b.Number);
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
            var round = tournament.Value.Rounds.First(r=>r.Number == 0);

            if(round.Batles.Count == 0)
                round.Batles.Add(new Batle {Id = Guid.NewGuid(), FirstTeam = team.Value, FirstTeamScore = 0 });
            else
            {
                var hasNullSecondTeam = round.Batles.FirstOrDefault(r => r.SecondTeam == null);

                if (hasNullSecondTeam != null)
                {
                    hasNullSecondTeam.SecondTeam = team.Value;
                    hasNullSecondTeam.SecondTeamScore = 0;
                }
                else
                {
                    round.Batles.Add(new Batle { Id = Guid.NewGuid(), FirstTeam = team.Value, FirstTeamScore = 0 });
                }
            }         
            return Result.Success();
        }
    }
}
