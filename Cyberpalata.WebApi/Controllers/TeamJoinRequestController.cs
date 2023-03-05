﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/joinRequests")]
    public class TeamJoinRequestController : BaseController
    {
        private readonly ITeamJoinRequestService _teamJoinRequestService;
        private readonly ITeamService _teamService;
        private readonly ILogger<TeamJoinRequestController> _logger;

        public TeamJoinRequestController(IUnitOfWork uinOfWork, ITeamJoinRequestService teamJoinRequestService, ITeamService teamService,ILogger<TeamJoinRequestController> logger) : base(uinOfWork)
        {
            _teamJoinRequestService = teamJoinRequestService;
            _teamService = teamService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("createJoinRequest")]
        public async Task<IActionResult> CreateJoinRequest(Guid teamId)
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _teamJoinRequestService.CreateJoinRequest(teamId, userId);

            if (result.IsFailure)
                return BadRequest(result);

            return await ReturnSuccess();
        }

        [Authorize]
        [HttpGet("getTeamJoinRequests")]
        public async Task<IActionResult> GetJoinRequests()
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var teamFilter = new TeamFilterBL
            {
                CurrentPage = 1,
                PageSize = 1,
                CaptainId = userId,
            };
            var team = await _teamService.GetPagedList(teamFilter);
            var teamJoinFilter = new TeamJoinRequestFilterBL
            {
                CurrentPage = 1,
                PageSize = 1,
                TeamId = team.Items.ElementAt(0).Id
            };

            if(teamJoinFilter.TeamId == Maybe.None)
                _logger.LogCritical("TeamID: is null");
            else
                _logger.LogCritical("TeamID: is not null");


            var requests = await _teamJoinRequestService.GetPagedList(teamJoinFilter);

            return Ok(requests);
        }
    }
}