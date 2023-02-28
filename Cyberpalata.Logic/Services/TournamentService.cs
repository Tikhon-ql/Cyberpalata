using AutoMapper;
using AutoMapper.Configuration.Conventions;
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
using System.Runtime.Serialization;

namespace Cyberpalata.Logic.Services
{
    internal class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IQrCodeService _qrCodeService;
        private readonly IBatleRepository _batleRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public TournamentService(ITournamentRepository repository, ITeamRepository teamRepository, 
                                 IMapper mapper, IQrCodeService qrCodeService, IConfiguration configuration,IBatleRepository batleRepository)
        {
            _tournamentRepository = repository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _qrCodeService = qrCodeService;
            _configuration = configuration;
            _batleRepository = batleRepository;
        }

        public async Task<Guid> CreateTournament(CreateTournamentViewModel viewModel)
        {
            var tournamentDto = _mapper.Map<TournamentDto>(viewModel);
            var id = await _tournamentRepository.CreateAsync(_mapper.Map<Tournament>(tournamentDto));
            return id;
        }

        //public async Task<List<GetTournamentViewModel>> GetActualTournaments()
        //{
        //    var tournaments = _tournamentRepository.GetAll();
        //    var actualTournaments = tournaments.Where(t=>t.Date > DateTime.UtcNow);
        //    return _mapper.Map<List<GetTournamentViewModel>>(actualTournaments);
        //}

        //private void InitTournamentTeam(TournamentTeamViewModel team,int maxCount,int count)
        //{
        //    if (count >= maxCount)
        //        return;
        //    else
        //    {
        //        Console.WriteLine(count);
        //        TournamentTeamViewModel children1;
        //        if (count >= maxCount - 1)
        //            children1 = new TournamentTeamViewModel { Name = "Team" + count };
        //        else
        //            children1 = new TournamentTeamViewModel();
        //        team.Children.Add(children1);
        //        count++;
        //        InitTournamentTeam(children1, maxCount, count);
        //        TournamentTeamViewModel children2;
        //        if(count >= maxCount)
        //            children2 = new TournamentTeamViewModel { Name = "Team" + count };
        //        else
        //            children2 = new TournamentTeamViewModel();
        //        team.Children.Add(children2);
        //        InitTournamentTeam(children2, maxCount, count);
        //    }
        //}


        //private void InitTree(TournamentTeamViewModel result, List<PhaseViewModel> orderedList, int index,int count)
        //{
        //    if (count >= orderedList.Count)
        //        return;
        //    {
        //        if(result.Name == String.Empty)
        //            result.Name = orderedList.ElementAt(index).ParentTeamName;
        //        var left = new TournamentTeamViewModel
        //        {
        //            Name = orderedList.ElementAt(index).FirstChildTeamName
        //        };
        //        result.Children.Add(left);
        //        index++;
        //        count++;
        //        InitTree(left, orderedList, index,count);
        //        var right = new TournamentTeamViewModel
        //        {
        //            Name = orderedList.ElementAt(index).SecondChildTeamName
        //        };
        //        result.Children.Add(left);
        //        InitTree(right, orderedList, index, count);
        //    }
        //}

        private void InitTree(TournamentBatleViewModel node, List<Batle> result)
        {
            //int index = 0;

            //if (count >= result.Count)
            //    return;
            //else
            //{
            //    if (index != 0)
            //    {
            //        var prevElem = result.ElementAt(index - 1);
            //        if (prevElem != null)
            //        {
            //            if (prevElem.Result.Winner == prevElem.FirstTeam)
            //            {
            //                node.FirstTeamName = prevElem.FirstTeam.Name;
            //            }
            //            else
            //            {
            //                node.SecondTeamName = prevElem.SecondTeam.Name;
            //            }
            //        }
            //    }
            //    var leftNode = new TournamentBatleViewModel();
            //    node.LeftBatle = leftNode;
            //    index++;
            //    count++;
            //    InitTree(leftNode,result,index,count);
            //    var rightNode = new TournamentBatleViewModel();
            //    node.RightBatle = rightNode;
            //    InitTree(rightNode, result, index, count);
            //}

        }

        public async Task<TournamentDetailedViewModel> GetTournamentDetailed(Guid tournamentId)
        {
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);

            var viewModel = new TournamentDetailedViewModel
            {
                TournamentId = tournament.Value.Id,
                Name = tournament.Value.Name,
                Date = tournament.Value.Date.ToString("d"),
                //RootTeam = new TournamentTeamViewModel()
            };

            //int[] arr = new int[10] {0,0,0,0,0,0,0,0,0,0 };
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

            //foreach(var batle in tournament.Value.Batles)
            //{
            //    viewModel.Batles.Add(new TournamentBatleViewModel
            //    {
            //        BatleId = batle.Id,
            //        FirstTeamId = batle.FirstTeam != null ? batle.FirstTeam.Id : Guid.Empty,
            //        SecondTeamId = batle.SecondTeam != null ? batle.SecondTeam.Id : Guid.Empty,
            //        FirstTeamName = batle.FirstTeam != null ? batle.FirstTeam.Name : "",
            //        SecondTeamName = batle.SecondTeam != null ? batle.SecondTeam.Name : "",
            //        RoundNumber = batle.RoundNumber
            //    });
            //    //arr[batle.RoundNumber]++;
            //}
            //viewModel.Batles.Add(new TournamentBatleViewModel
            //{
            //    BatleId = Guid.Empty,
            //    FirstTeamId = Guid.Empty,
            //    SecondTeamId = Guid.Empty,
            //    FirstTeamName = "",
            //    SecondTeamName = "",
            //    RoundNumber = 1
            //});
            //viewModel.Batles.Add(new TournamentBatleViewModel
            //{
            //    BatleId = Guid.Empty,
            //    FirstTeamId = Guid.Empty,
            //    SecondTeamId = Guid.Empty,
            //    FirstTeamName = "",
            //    SecondTeamName = "",
            //    RoundNumber = 1
            //});
            //viewModel.Batles.Add(new TournamentBatleViewModel
            //{
            //    BatleId = Guid.Empty,
            //    FirstTeamId = Guid.Empty,
            //    SecondTeamId = Guid.Empty,
            //    FirstTeamName = "",
            //    SecondTeamName = "",
            //    RoundNumber = 2
            //});

            viewModel.Batles = viewModel.Batles.OrderByDescending(b => b.RoundNumber).ToList();


            //foreach (var batleResult in tournament.Value.BatleResults.OrderBy(b => b.RoundNumber))
            //{
            //    //var phase = new PhaseViewModel
            //    //{
            //    //    ParentTeamName = batleResult.Winner.Name,
            //    //    FirstChildTeamName = batleResult.Batle.FirstTeam.Name,
            //    //    SecondChildTeamName = batleResult.Batle.SecondTeam.Name,
            //    //    RoundNumber = batleResult.RoundNumber
            //    //};
            //    //phases.Add(phase);

            //}

            int[] s = new int[]{ 1, 2, 4 };

            //for(int i = 0;i<4;i++)
            //{
            //    viewModel.Phases.Add(new PhaseViewModel
            //    {
            //        ParentTeamName = $"",
            //        FirstChildTeamName = $"Team1{i}",
            //        SecondChildTeamName = $"Team2{i}",
            //        RoundNumber = 0
            //    });
            //}
            //for(int i = 0;i<2;i++)
            //{
            //    viewModel.Phases.Add(new PhaseViewModel
            //    {
            //        ParentTeamName = $"",
            //        FirstChildTeamName = $"",
            //        SecondChildTeamName = $"",
            //        RoundNumber = 1
            //    });

            //}
            //for (int i = 0; i < 1; i++)
            //{
            //    viewModel.Phases.Add(new PhaseViewModel
            //    {
            //        ParentTeamName = $"",
            //        FirstChildTeamName = $"",
            //        SecondChildTeamName = $"",
            //        RoundNumber = 2
            //    });
            //}

            //viewModel.Phases = viewModel.Phases.OrderByDescending(p => p.RoundNumber).ToList();


            //InitTree(viewModel.Root, viewModel.Phases.OrderByDescending(p=>p.RoundNumber).ToList(),0,0);

            //int count = 0;
            //InitTournamentTeam(viewModel.RootTeam,4 , count);

            return viewModel;

        }

        public async Task<Result<TeamRegistrationViewModel>> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            //tournament.Value.Batles.Add(new Batle 
            //{ 
            //   FirstTeam = team.Value
            //});
            //var round = tournament.Value.Rounds.FirstOrDefault(r=>r.Number == 0);

            //AddingTeamIntoBatle(round, team.Value);
            //var qrCodeBytes = _qrCodeService.TeamRegistrationQrCodeGeneration(new Models.QrCode.TeamRegistrationQrCodeModel
            //{
            //    Url = _configuration["ConfirmTeamComing"],
            //    TeamId = viewModel.TeamId,
            //    TournamentId = viewModel.TournamentId
            //});

            //var teamRegistrationQrCode = new TeamRegistrationQrCode
            //{
            //    Id = Guid.NewGuid(),
            //    BitmapBytes = qrCodeBytes,
            //    Date = DateTime.UtcNow,
            //    Team = team.Value,
            //    Tournament = tournament.Value
            //};

            //_teamRegistrationQrCodeRepository.CreateAsync(teamRegistrationQrCode);
         
            var team = await _teamRepository.ReadAsync(viewModel.TeamId);
            if (team.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Team with sended id doesn't exist");
            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Tournament with sended id doesn't exist");

            var batleFilter = new BatleFilter
            {
                CurrentPage = 1,
                PageSize = 100,//??? 
                IsActual = true,
                TournamentId = tournament.Value.Id
            };

            var batles = await _batleRepository.GetPageListAsync(batleFilter);

            bool isTeamAdded = false;

            foreach(var batle in batles.Items)
            {
                if (batle.SecondTeam == null)
                {
                    batle.SecondTeam = team.Value;
                    isTeamAdded = true;
                    batle.Date = DateTime.UtcNow;
                    break;
                }
            }
            if(!isTeamAdded)
            {
                tournament.Value.Batles.Add(new Batle
                {
                    Id = Guid.NewGuid(),
                    FirstTeam = team.Value,
                    Tournament = tournament.Value,
                    Date = DateTime.UtcNow.AddDays(100)
                });
            }

            var responseViewModel = new TeamRegistrationViewModel
            {
                TeamId = team.Value.Id,
                TournamentId = tournament.Value.Id,
            };

            return Result.Success(responseViewModel);
        }

        //private void AddingTeamIntoBatle(Round round, Team team)///??? Can i do like that
        //{
        //    if (round != null)
        //    {
        //        if (round.Batles.Count == 0)
        //            round.Batles.Add(new Batle { Id = Guid.NewGuid(), FirstTeam = team, FirstTeamScore = 0 });
        //        else
        //        {
        //            var hasNullSecondTeam = round.Batles.FirstOrDefault(r => r.SecondTeam == null);
        //            if (hasNullSecondTeam != null)
        //            {
        //                hasNullSecondTeam.SecondTeam = team;
        //                hasNullSecondTeam.SecondTeamScore = 0;
        //            }
        //            else
        //            {
        //                round.Batles.Add(new Batle { Id = Guid.NewGuid(), FirstTeam = team, FirstTeamScore = 0 });
        //            }
        //        }
        //    }
        //}

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
