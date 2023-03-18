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

        public async Task<Result> AddUserToTeam(Guid userId, Guid teamId)
        {
            var user = await _userRepository.ReadAsync(userId);
            if (user.HasNoValue)
                return Result.Failure($"User with id: {userId} not found");
            var team = await _repository.ReadAsync(teamId);
            if(team.HasNoValue)
                return Result.Failure($"Team with id: {teamId} not found");
            team.Value.Members.Add(new TeamMember()
            {
                Id = Guid.NewGuid(),
                Member = user.Value,
                Team = team.Value,
                IsCaptain = false,
            });

            return Result.Success();
        }

        private async Task<Result> ValidateTeam(CreateTeamViewModel viewModel)
        {
            if (viewModel.Name.Contains(' ') || viewModel.Name.Contains(';') || viewModel.Name.Contains('>')
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
                return Result.Failure("Team name contains bad symbol");
            return Result.Success();
        }
 
        public async Task<Result> CreateAsync(CreateTeamViewModel request)
        {
            var validationResult = await ValidateTeam(request);
            if (validationResult.IsFailure)
                return validationResult;
            var captain = await _userRepository.ReadAsync(request.CaptainId);
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
            captain.Value.Team = team;
            await _repository.CreateAsync(team);
            return Result.Success();
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

        public async Task<Result> DeleteTeam(Guid teamId)
        {
            var team = await _repository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Result.Failure($"Team with id {teamId} not found");
            foreach (var member in team.Value.Members.ToList())
            {
                var result = await KickMember(teamId, member.MemberId.Value);
                if (result.IsFailure)
                    return result;
            }
            _repository.Delete(team.Value);
            return Result.Success();
        }

        public async Task<Result> KickMember(Guid teamId,Guid memberId)
        {
            var team = await _repository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Result.Failure($"Team with id {teamId} not found");
            var member = team.Value.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member == null)
                return Result.Failure("User doesn't participate in the team");
            member.Member.Team = null;
            foreach(var request in member.JoinRequests.ToList())
            {
                member.JoinRequests.Remove(request);
            }
            team.Value.Members.Remove(member);
            //member.Member.Team = null;
            return Result.Success();
        }
    }
}
