using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Interfaces.Services;

namespace Cyberpalata.Logic.Services
{
    internal class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamJoinRequestRepository _teamJoinRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TeamMemberService(ITeamRepository teamRepository, IMapper mapper,ITeamMemberRepository teamMemberRepository, ITeamJoinRequestRepository teamJoinRequestRepository,IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
            _teamJoinRequestRepository = teamJoinRequestRepository;
            _userRepository = userRepository;
        }

        public async Task<Result> AddJoinRequest(Guid teamId, Guid userId)
        {
            var captain = await ReadCaptainByTeamId(teamId);
            if (captain.HasNoValue)
                return Result.Failure("Captain not found");
            var user = await _userRepository.ReadAsync(userId);
            var request = new TeamJoinRequest
            {
                Team = captain.Value.Team,
                User = user.Value
            };
            captain.Value.JoinRequests.Add(request);
            await _teamJoinRequestRepository.CreateAsync(request);
            return Result.Success();
        }

        private async Task<Maybe<TeamMember>> ReadCaptainByTeamId(Guid teamId)
        {
            var team = await _teamRepository.ReadAsync(teamId);
            if (team.HasNoValue)
                return Maybe.None;
            var captain = team.Value.Members.FirstOrDefault(m => m.IsCaptain);
            return captain;
        }
    }
}
