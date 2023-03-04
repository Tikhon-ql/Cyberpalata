using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Interfaces.Services;

namespace Cyberpalata.Logic.Services
{
    internal class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamJoinRequestRepository _teamJoinRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;

        public TeamMemberService(ITeamRepository teamRepository, ITeamJoinRequestRepository teamJoinRequestRepository,IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _teamRepository = teamRepository;
            _teamJoinRequestRepository = teamJoinRequestRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
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
            var notification = new Notification
            {
                User = captain.Value.Member,
                Text = $"{user.Value.Username} {user.Value.Surname} have sent you a join request\nTo accept go to profile",
                Date = DateTime.UtcNow,
            };
            captain.Value.Member.Notifications.Add(notification);
            captain.Value.JoinRequests.Add(request);
            await _notificationRepository.CreateAsync(notification);
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
