using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.Logic.Filters;
using AutoMapper;
using Cyberpalata.DataProvider.Filters;
using Microsoft.Extensions.Logging;
using Cyberpalata.Common.Enums;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.Logic.Services
{
    internal class TeamJoinRequestService : ITeamJoinRequestService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamJoinRequestRepository _teamJoinRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamJoinRequestService> _logger;

        public TeamJoinRequestService(IChatRepository chatRepository,ITeamRepository teamRepository,IMapper mapper, ITeamJoinRequestRepository teamJoinRequestRepository, IUserRepository userRepository, INotificationRepository notificationRepository, ILogger<TeamJoinRequestService> logger)
        {
            _teamRepository = teamRepository;
            _teamJoinRequestRepository = teamJoinRequestRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
            _chatRepository = chatRepository;
        }

        private async Task CreateNewChat(Team team, User userToJoin)
        {
            var captain = await ReadCaptainByTeamId(team.Id);

            var chat = new Chat
            {
                Captain = captain.Value.Member,
                UserToJoin = userToJoin,
            };
            await _chatRepository.CreateAsync(chat);
            await SendNotification(userToJoin, $"{team.Name} ready to chat with you");
        }

        private async Task SendNotification(User user, string text)
        {
            var notification = new Notification
            {
                User = user,
                CreatedDate = DateTime.UtcNow,
                Text = text
            };
            await _notificationRepository.CreateAsync(notification);
        }

        public async Task<Result> SetJoinRequestState(JoinRequestStateSettingViewModel viewModel,JoinRequestState currentState, JoinRequestState stateToSet)
        {
            var userToJoin = await _userRepository.ReadAsync(viewModel.UserToJoinId);
            if (userToJoin.HasNoValue)
                return Result.Failure($"User with id: ${viewModel.UserToJoinId} not found");

            var filter = new TeamJoinRequestFilter()
            {
                CurrentPage = 1,
                PageSize = 1,
                TeamId = viewModel.TeamId,
                UserToJoinId = viewModel.UserToJoinId,
                State = new List<JoinRequestState> { currentState }
            };
            var requests = (await _teamJoinRequestRepository.GetPageListAsync(filter)).Items;
            var request = new TeamJoinRequest();
            if (requests.Count > 0)
                request = requests[0];
            else
                return Result.Failure("You are not a captain of the team");
            request.State = stateToSet;

            if(stateToSet == JoinRequestState.InProgress)
            {
                await CreateNewChat(request.Team, userToJoin.Value);
            }

            await SendNotification(userToJoin.Value, $"Your request had been {stateToSet.Name.ToLower()}");

            return Result.Success();
        }

        private async Task<Result> ValidateIsAlredySentRequest(Guid teamId, Guid userId)
        {
            var filter = new TeamJoinRequestFilter()
            {
                CurrentPage = 1,
                PageSize = 1,
                TeamId = teamId,
                UserToJoinId = userId,
                State = new List<JoinRequestState> { JoinRequestState.None, JoinRequestState.InProgress }
            };
            var requests = await _teamJoinRequestRepository.GetPageListAsync(filter);
            if (requests.Items.Count > 0)
                return Result.Failure("You already sent request");
            return Result.Success();
        }
        private async Task<Result> ValidateUserHasTeam(Guid userId)
        {
            var teamFilter = new TeamFilter
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                MemberId = userId,
            };
            var teams = await _teamRepository.GetPageListAsync(teamFilter);
            if (teams.Items.Count > 0)
                return Result.Failure("You are already participate in the team.\nYou can leave it in your profile");
            return Result.Success();
        }

        private async Task<Result> ValidateRequest(Guid teamId, Guid userId)
        {
            var isSentResult = await ValidateIsAlredySentRequest(teamId, userId);
            if (isSentResult.IsFailure)
                return isSentResult;
            var isHasTeamResult = await ValidateUserHasTeam(userId);
            if (isHasTeamResult.IsFailure)
                return isHasTeamResult;
            return Result.Success();
        }

        public async Task<Result> CreateJoinRequest(Guid teamId, Guid userId)
        {
            var result = await ValidateRequest(teamId, userId);
            if (result.IsFailure)
                return result;
            _logger.LogCritical(teamId.ToString());
            var captain = await ReadCaptainByTeamId(teamId);
            if (captain.HasNoValue)
                return Result.Failure("Captain not found");
            var user = await _userRepository.ReadAsync(userId);
            var request = new TeamJoinRequest
            {
                Team = captain.Value.Team,
                User = user.Value,
            };
            await SendNotification(captain.Value.Member, $"{user.Value.Username} {user.Value.Surname} have sent you a join request.\nTo accept go to profile");
            captain.Value.JoinRequests.Add(request);
            await _teamJoinRequestRepository.CreateAsync(request);
            return Result.Success();
        }

        public async Task<PagedList<TeamJoinRequestDto>> GetPagedList(TeamJoinRequestFilterBL filter)
        {
            _logger.LogCritical(filter.ToString());
            _logger.LogCritical(filter.TeamId.Value.ToString());
            var list = await _teamJoinRequestRepository.GetPageListAsync(_mapper.Map<TeamJoinRequestFilter>(filter));
            return _mapper.Map<PagedList<TeamJoinRequestDto>>(list);
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
