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
        private readonly IQrCodeService _qrCodeService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public TournamentService(ITournamentRepository repository, ITeamRepository teamRepository, 
                                 IMapper mapper, IQrCodeService qrCodeService, IConfiguration configuration)
        {
            _tournamentRepository = repository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _qrCodeService = qrCodeService;
            _configuration = configuration;
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

        public async Task<Result<TeamRegistrationViewModel>> RegisterTeam(RegisterTeamViewModel viewModel)
        {
            var team = await _teamRepository.ReadAsync(viewModel.TeamId);
            if (team.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Team with sended id doesn't exist");
            var tournament = await _tournamentRepository.ReadAsync(viewModel.TournamentId);
            if (tournament.HasNoValue)
                return Result.Failure<TeamRegistrationViewModel>("Tournament with sended id doesn't exist");

            tournament.Value.Teams.Add(team.Value);
            var round = tournament.Value.Rounds.FirstOrDefault(r=>r.Number == 0);

            AddingTeamIntoBatle(round, team.Value);
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

            var responseViewModel = new TeamRegistrationViewModel
            {
                TeamId = team.Value.Id,
                TournamentId = tournament.Value.Id,
            };

            return Result.Success(responseViewModel);
        }

        private void AddingTeamIntoBatle(Round round, Team team)///??? Can i do like that
        {
            if (round != null)
            {
                if (round.Batles.Count == 0)
                    round.Batles.Add(new Batle { Id = Guid.NewGuid(), FirstTeam = team, FirstTeamScore = 0 });
                else
                {
                    var hasNullSecondTeam = round.Batles.FirstOrDefault(r => r.SecondTeam == null);
                    if (hasNullSecondTeam != null)
                    {
                        hasNullSecondTeam.SecondTeam = team;
                        hasNullSecondTeam.SecondTeamScore = 0;
                    }
                    else
                    {
                        round.Batles.Add(new Batle { Id = Guid.NewGuid(), FirstTeam = team, FirstTeamScore = 0 });
                    }
                }
            }
        }

        public async Task<PagedList<TournamentDto>> GetPagedList(TournamentFilterBL filter)
        {
            var list = await _tournamentRepository.GetPageListAsync(_mapper.Map<TournamentFilter>(filter));
            return _mapper.Map<PagedList<TournamentDto>>(list);
        }

    }
}
