using AutoMapper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response;
using Cyberpalata.ViewModel.Response.Tournament;

namespace Cyberpalata.Logic.Services
{
    internal class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public TeamService(ITeamRepository repository, IUserRepository userRepository, IMapper mapper,ITournamentRepository tournamentRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task CreateAsync(CreateTeamViewModel request)
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            team.Members = new List<TeamMember>();
            team.Members.Add(new TeamMember
            {
                MemberId = request.CaptainId,
                IsCaptain = true,
                TeamId = team.Id
            });
            await _repository.CreateAsync(team);
        }

        public async Task<PagedList<TeamDto>> GetPagedList(TeamFilterBL filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<TeamFilter>(filter));
            return _mapper.Map<PagedList<TeamDto>>(list);
        }

        public async Task<Maybe<TeamDetailViewModel>> GetTeamDetailed(Guid teamId)
        {
            var team = await _repository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Maybe.None;
            var teamDto = _mapper.Map<TeamDto>(team.Value);
            return _mapper.Map<TeamDetailViewModel>(teamDto);
        }

        public async Task<Result<TeamDetailViewModel>> GetTeamInTournament(Guid teamId, Guid tournamentId)
        {
            var team = await _repository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Result.Failure<TeamDetailViewModel>($"Team with id: {teamId} doesn't exist");
            var tournament = await _tournamentRepository.ReadAsync(tournamentId);
            if (team.HasNoValue)
                return Result.Failure<TeamDetailViewModel>($"Tournament with id: {teamId} doesn't exist");
            if (!tournament.Value.Batles.Any(b => b.FirstTeam.Id == teamId || b.SecondTeam.Id == teamId))
                return Result.Failure<TeamDetailViewModel>($"This team doesn't apart in tournament");

            var teamDto = _mapper.Map<TeamDto>(team.Value);
            return _mapper.Map<TeamDetailViewModel>(teamDto);
        }

        public async Task SetHiringState(Guid teamId, bool state)
        {
            var team = await _repository.ReadAsync(teamId);
            if (team.HasNoValue)
                return;
            team.Value.IsHiring = state;
        }
    }
}
