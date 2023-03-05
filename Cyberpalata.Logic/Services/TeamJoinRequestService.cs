﻿using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.Logic.Filters;
using AutoMapper;
using Cyberpalata.DataProvider.Filters;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Cyberpalata.Common.Enums;
using Cyberpalata.ViewModel.Request.Tournament;

namespace Cyberpalata.Logic.Services
{
    internal class TeamJoinRequestService : ITeamJoinRequestService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamJoinRequestRepository _teamJoinRequestRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamJoinRequestService> _logger;

        public TeamJoinRequestService(ITeamRepository teamRepository,IMapper mapper, ITeamJoinRequestRepository teamJoinRequestRepository, IUserRepository userRepository, INotificationRepository notificationRepository, ILogger<TeamJoinRequestService> logger)
        {
            _teamRepository = teamRepository;
            _teamJoinRequestRepository = teamJoinRequestRepository;
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> SetJoinRequestState(JoinRequestStateSettingViewModel viewModel)
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
                State = JoinRequestState.InProgress
            };
            var request = (await _teamJoinRequestRepository.GetPageListAsync(filter)).Items.ElementAt(0);
            var state = JoinRequestState.Parse(viewModel.State);
            request.State = state;

            var notification = new Notification
            {
                User = userToJoin.Value,
                CreatedDate = DateTime.UtcNow,
                Text = $"Your request had been {state.Name}"
            };
            await _notificationRepository.CreateAsync(notification);

            return Result.Success();
        }

        public async Task<Result> CreateJoinRequest(Guid teamId, Guid userId)
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
                Text = $"{user.Value.Username} {user.Value.Surname} have sent you a join request.\nTo accept go to profile",
                CreatedDate = DateTime.UtcNow,
            };
            captain.Value.Member.Notifications.Add(notification);
            captain.Value.JoinRequests.Add(request);
            await _notificationRepository.CreateAsync(notification);
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
