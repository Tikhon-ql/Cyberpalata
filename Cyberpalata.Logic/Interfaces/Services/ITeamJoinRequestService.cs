using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Models.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface ITeamJoinRequestService
    {
        Task<Result> CreateJoinRequest(Guid teamId, Guid userId);
        Task<PagedList<TeamJoinRequestDto>> GetPagedList(TeamJoinRequestFilterBL filter);
    }
}
