﻿using CSharpFunctionalExtensions;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Cyberpalata.WebApi.Controllers
{
    [ApiController]
    [Route("/teams")]
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService, IUnitOfWork uinOfWork) : base(uinOfWork)
        {
            _teamService = teamService;
        }

        [Authorize]
        [HttpPost("createTeam")]
        public async Task<IActionResult> CreateTeam(CreateTeamViewModel viewModel)
        {
            var id = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            viewModel.CaptainId = id;
            var result = await _teamService.CreateAsync(viewModel);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [HttpGet("getTeam")]
        public async Task<IActionResult> GetTeam(Guid teamId)
        {
            var viewModel = await _teamService.GetTeamDetailed(teamId);
            if (viewModel.HasNoValue)
                return BadRequest(viewModel);
            return await ReturnSuccess(viewModel.Value);
        }

        [Authorize]
        [HttpGet("getTeamInTournament")]
        public async Task<IActionResult> GetTeamInTournament(Guid teamId, Guid tournamentId)
        {
            var viewModelResult = await _teamService.GetTeamInTournament(teamId, tournamentId);
            if (viewModelResult.IsFailure)
                return BadRequestJson(viewModelResult);
            return await ReturnSuccess(viewModelResult.Value);
        }


        [Authorize]
        [HttpDelete("deleteTeam")]
        public async Task<IActionResult> DeleteTeam(Guid teamId)
        {
            var result = await _teamService.DeleteTeam(teamId);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }

        [Authorize]
        [HttpDelete("leaveTeam")]
        public async Task<IActionResult> LeaveTeam(Guid teamId)
        {
            var userId = Guid.Parse(User.Claims.First(claim=>claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var result = await _teamService.KickMember(teamId, userId);
            if (result.IsFailure)
                return BadRequestJson(result);
            return await ReturnSuccess();
        }


        [HttpPut("setRecruting")]
        public async Task<IActionResult> SendTeamRecrutingStateChange(TeamRecrutingStateChangeViewModel viewModel)
        {
            await _teamService.SetRecrutingState(viewModel.TeamId, viewModel.State);
            return await ReturnSuccess();
        }

        [HttpGet("getHiringTeams")]
        public async Task<IActionResult> GetRecrutingTeams(int page)
        {
            var teamFilter = new TeamFilterBL
            {
                CurrentPage = page,
                PageSize = 5,
                IsRecruting = true,
            };

            var result = await _teamService.GetPagedList(teamFilter);
            var viewModel = new List<RecrutingTeamViewModel>();
            foreach (var team in result.Items)
            {
                viewModel.Add(new RecrutingTeamViewModel
                {
                    Id = team.Id,
                    CaptainId = team.Captain.Member.Id,
                    Name = team.Name
                });
            }
            return Ok(new { Items = viewModel, PageSize = result.PageSize, TotalItemsCount = result.TotalItemsCount });
        }

        [HttpGet("topTeams")]
        public async Task<IActionResult> GetTopTeams(int page)
        {
            var filter = new TeamFilterBL
            {
                CurrentPage = page,
                PageSize = 10,
                IsTop = true,
            };
            var teams = await _teamService.GetPagedList(filter);
            var viewModel = new List<TeamTopViewModel>();
            foreach(var team in teams.Items)
            {
                viewModel.Add(new TeamTopViewModel
                {
                    Name = team.Name,
                    WinCount = team.WinCount
                });
            }
            return Ok(new { Items = viewModel, PageSize = teams.PageSize, TotalItemsCount = teams.TotalItemsCount });
        }

        [Authorize]
        [HttpGet("getUserTeam")]
        public async Task<IActionResult> GetUserTeam()
        {
            var userId = Guid.Parse(User.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sid).Value);
            var filter = new TeamFilterBL
            {
                CurrentPage = 1,
                PageSize = 1,
                MemberId = userId,
            };
            var team = (await _teamService.GetPagedList(filter)).Items.ElementAt(0);

            var viewModel = new TeamDetailViewModel
            {
                Id = team.Id,
                CaptainName = $"{team.Captain.Member.Username} {team.Captain.Member.Surname}",
                Name = team.Name,
                Members = team.Members.OrderByDescending(m=>m.IsCaptain).Select(m => new TeamMemberViewModel {
                    Name = $"{m.Member.Username} {m.Member.Surname}",
                    Position = m.IsCaptain ? "Captain" : "Member"
                }).ToList(),
                IsTeamRecruting = team.IsRecruting
            };
            return Ok(viewModel);
        }

        [Authorize]
        [HttpGet("getByUserId")]
        public async Task<IActionResult> GetTeamsByUserId()
        {
            var userId = Guid.Parse(User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sid).Value);
            var filter = new TeamFilterBL
            {
                CurrentPage = 1,
                PageSize = int.MaxValue,
                CaptainId = userId
            };
            var list = await _teamService.GetPagedList(filter);
            var viewModel = new List<GetTeamViewModel>();
            foreach (var team in list.Items)
            {
                viewModel.Add(new GetTeamViewModel
                {
                    Id = team.Id,
                    Name = team.Name,
                    CaptainName = $"{team.Captain.Member.Username} {team.Captain.Member.Surname}"
                });
            }
            return await ReturnSuccess(viewModel);
        }
    }
}
