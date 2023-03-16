using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Services
{
    internal class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IBatleRepository _batleRepository;
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository repository, ITeamRepository teamRepository, 
                                 IMapper mapper,IBatleRepository batleRepository)
        {
            _tournamentRepository = repository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _batleRepository = batleRepository;
        }

        private async Task<Result> ValidateTournament(CreateTournamentViewModel viewModel)
        {
            var date = DateTime.Parse(viewModel.Date);
            if (date.Add(viewModel.Begining) < DateTime.UtcNow)
                return Result.Failure("Date is in the past");
            if (viewModel.Name.Contains(';') || viewModel.Name.Contains('>')
             || viewModel.Name.Contains(';') || viewModel.Name.Contains('<')
             || viewModel.Name.Contains('-') || viewModel.Name.Contains('*') 
             || viewModel.Name.Contains('+') || viewModel.Name.Contains('-') 
             || viewModel.Name.Contains('(') || viewModel.Name.Contains(')') 
             || viewModel.Name.Contains('[') || viewModel.Name.Contains(']') 
             || viewModel.Name.Contains('{') || viewModel.Name.Contains('}') 
             || viewModel.Name.Contains('\\') || viewModel.Name.Contains('/') 
             || viewModel.Name.Contains('.') || viewModel.Name.Contains('\'')
             || viewModel.Name.Contains(',') || viewModel.Name.Contains('?')
             || viewModel.Name.Contains('!') || viewModel.Name.Contains('_'))
                return Result.Failure("Tournament name contains bad symbol");
            return Result.Success();
        }

        public async Task<Result<Guid>> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var result = await ValidateTournament(viewModel);
            if (result.IsFailure)
                return Result.Failure<Guid>(result.Error);
            var tournamentDto = _mapper.Map<TournamentDto>(viewModel);
            var id = await _tournamentRepository.CreateAsync(_mapper.Map<Tournament>(tournamentDto));
            return id;
        }

        public async Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId)
        {
            var tournament = (await _tournamentRepository.ReadAsync(tournamentId)).Value;

            var viewModel = new TournamentDetailedViewModel
            {
                TournamentId = tournament.Id,
                Name = tournament.Name,
                Date = tournament.Date.ToString("d"),
                Winner = "",
            };
            #region Move to separate method
            for (int i = 0;i < tournament.RoundsCount;i++)
            {
                var roundBatles = tournament.Batles.Where(b=>b.RoundNumber == i).ToList();
                roundBatles.Sort((a,b) => a.Number - b.Number);
                var maxBaltesCount = Math.Pow(2.0, tournament.RoundsCount - i - 1);
                if (roundBatles.Count <= maxBaltesCount)
                {
                    for (int j = 0; j < roundBatles.Count; j++)
                    {
                        var batle = roundBatles[j];
                        viewModel.Batles.Add(new TournamentBatleViewModel
                        {
                            BatleId = batle.Id,
                            FirstTeamId = batle.FirstTeam != null ? batle.FirstTeam.Id : Guid.Empty,
                            SecondTeamId = batle.SecondTeam != null ? batle.SecondTeam.Id : Guid.Empty,
                            FirstTeamName = batle.FirstTeam != null ? batle.FirstTeam.Name : "",
                            SecondTeamName = batle.SecondTeam != null ? batle.SecondTeam.Name : "",
                            RoundNumber = batle.RoundNumber
                        });
                    }
                    for(int j = roundBatles.Count; j < maxBaltesCount;j++)
                    {
                        viewModel.Batles.Add(new TournamentBatleViewModel
                        {
                            BatleId = Guid.Empty,
                            FirstTeamId = Guid.Empty,
                            SecondTeamId = Guid.Empty,
                            FirstTeamName = "",
                            SecondTeamName = "",
                            RoundNumber = i
                        });
                    }
                }
                else
                {
                    foreach (var batle in roundBatles)
                    {
                        viewModel.Batles.Add(new TournamentBatleViewModel
                        {
                            BatleId = Guid.Empty,
                            FirstTeamId = Guid.Empty,
                            SecondTeamId = Guid.Empty,
                            FirstTeamName = "",
                            SecondTeamName = "",
                            RoundNumber = i
                        });
                    }
                }
            }
            #endregion
            viewModel.Batles = viewModel.Batles.OrderByDescending(b => b.RoundNumber).ToList();
            if (tournament.Winner != null)
                viewModel.Winner = tournament.Winner.Name;
            return viewModel;
        }
        private async Task AddTeamToBatle(BatleFilter filter,Tournament tournament, Team team)
        {
            var batles = await _batleRepository.GetPageListAsync(filter);
            foreach(var batle in batles.Items)
            {
                if (batle.SecondTeam == null)
                {
                    batle.SecondTeam = team;
                    batle.Date = DateTime.UtcNow;
                    return;
                }
            }
            var newBatle = new Batle
            {
                Id = Guid.NewGuid(),
                FirstTeam = team,
                Tournament = tournament,
                Date = DateTime.UtcNow.AddDays(100),
                Number = tournament.Batles.Count,
            };
            tournament.Batles.Add(newBatle);
        }

        private async Task<bool> AlreadyInTournament(Team team, Tournament tournament)
        {
            foreach(var batle in tournament.Batles)
            {
                if (batle.FirstTeam == team || batle.SecondTeam == team)
                    return true;
            }
            return false;
        }

        

        public async Task<Result<TeamRegistrationViewModel>> RegisterTeam(RegisterTeamViewModel viewModel, Guid userId)
        {
            var teamFilter = new TeamFilter
            {
                CurrentPage = 1,
                PageSize = 1,
                MemberId = userId,
            };
            var userTeam = await _teamRepository.GetPageListAsync(teamFilter);
            if (userTeam.Items.Count == 0)
                return Result.Failure<TeamRegistrationViewModel>("You aren't in a team");
            var team = userTeam.Items.ElementAt(0);


            //if (team.Members.Count < 5)
            //    return Result.Failure<TeamRegistrationViewModel>("Your team is understaffed");

            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Tournament with sended id doesn't exist");

            if (await AlreadyInTournament(team, tournament.Value))
                return Result.Failure<TeamRegistrationViewModel>("Your team is alredy participate in the tournament");

            var batleFilter = new BatleFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                IsActual = true,
                TournamentId = tournament.Value.Id
            };

            await AddTeamToBatle(batleFilter, tournament.Value, team);

            var responseViewModel = new TeamRegistrationViewModel
            {
                TeamId = team.Id,
                TournamentId = tournament.Value.Id,
            };

            return Result.Success(responseViewModel);
        }

        public async Task<PagedList<TournamentDto>> GetPagedList(TournamentFilterBL filter)
        {
            var list = await _tournamentRepository.GetPageListAsync(_mapper.Map<TournamentFilter>(filter));
            return _mapper.Map<PagedList<TournamentDto>>(list);
        }

        public async Task<TournamentSmalViewModel> GetTournamentSmall(Guid tournamentId)
        {
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);
            var viewModel = new TournamentSmalViewModel
            {
                Name = tournament.Value.Name,
                Date = tournament.Value.Date.ToString("d")
            };
            return viewModel;
        }

        public async Task<Result> ApproveTeam(Guid teamId, Guid tournamentId)
        {
            var team = await _teamRepository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Result.Failure($"Team with id: {teamId} not found");
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);
            if (tournament.HasNoValue)
                return Result.Failure($"Tournamet with id: {tournamentId} not found");

            foreach(var batle in tournament.Value.Batles)
            {
                if(batle.FirstTeam == team.Value)
                {
                    batle.IsFirstTeamApproved = true;
                    return Result.Success();
                }
                if(batle.SecondTeam == team.Value)
                {
                    batle.IsSecondTeamApproved = true;
                    return Result.Success();
                }
            }

            return Result.Failure("Team isn't participate in the tournament");
        }
    }
}
