﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITeamJoinRequestService
    {
        Task<Result> CreateJoinRequest(Guid teamId, Guid userId);
        Task<PagedList<TeamJoinRequestDto>> GetPagedList(TeamJoinRequestFilterBL filter);
        Task<Result> SetJoinRequestState(JoinRequestStateSettingViewModel viewModel,JoinRequestState currentState, JoinRequestState stateToSet);
    }
}
