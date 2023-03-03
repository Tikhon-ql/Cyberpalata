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
using Microsoft.Extensions.Configuration;
using System.Formats.Asn1;

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

        public async Task<Guid> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var tournamentDto = _mapper.Map<TournamentDto>(viewModel);
            var id = await _tournamentRepository.CreateAsync(_mapper.Map<Tournament>(tournamentDto));
            return id;
        }

        public async Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId)
        {
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);

            var viewModel = new TournamentDetailedViewModel
            {
                TournamentId = tournament.Value.Id,
                Name = tournament.Value.Name,
                Date = tournament.Value.Date.ToString("d"),
            };

            for(int i = 0;i < tournament.Value.RoundsCount;i++)
            {
                var roundBatles = tournament.Value.Batles.Where(b=>b.RoundNumber == i).ToList();
                var maxBaltesCount = Math.Pow(2.0, tournament.Value.RoundsCount - i - 1);
                if (roundBatles.Count < maxBaltesCount)
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

            viewModel.Batles = viewModel.Batles.OrderByDescending(b => b.RoundNumber).ToList();

            return viewModel;
        }

        private async Task AddTeamToBatle(BatleFilter filter,Tournament tournament, Team team)
        {
            var batles = await _batleRepository.GetPageListAsync(filter);

            bool isTeamAdded = false;

            foreach (var batle in batles.Items)
            {
                if (batle.SecondTeam == null)
                {
                    batle.SecondTeam = team;
                    isTeamAdded = true;
                    batle.Date = DateTime.UtcNow;
                    break;
                }
            }
            if (!isTeamAdded)
            {
                tournament.Batles.Add(new Batle
                {
                    Id = Guid.NewGuid(),
                    FirstTeam = team,
                    Tournament = tournament,
                    Date = DateTime.UtcNow.AddDays(100)
                });
            }
        }

        public async Task<Result<TeamRegistrationViewModel>> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var team = await _teamRepository.ReadAsync(viewModel.TeamId);
            if (team.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Team with sended id doesn't exist");
            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Tournament with sended id doesn't exist");

            var batleFilter = new BatleFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                IsActual = true,
                TournamentId = tournament.Value.Id
            };

            await AddTeamToBatle(batleFilter, tournament.Value, team.Value);

            var responseViewModel = new TeamRegistrationViewModel
            {
                TeamId = team.Value.Id,
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
    }
}
