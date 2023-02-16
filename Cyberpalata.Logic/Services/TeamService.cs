using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Models.Tournaments;
using Cyberpalata.Logic.Configuration.MapperConfiguration;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Room;
using Cyberpalata.Logic.Models.Tournament;
using Cyberpalata.ViewModel.Request.Tournament;
using Cyberpalata.ViewModel.Response.Tournament;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TeamService(ITeamRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
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
            //team.Members.Add(user.Value);
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
            return _mapper.Map<TeamDetailViewModel>(team);
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
