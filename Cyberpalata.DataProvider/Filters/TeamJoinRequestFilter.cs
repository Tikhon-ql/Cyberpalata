using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class TeamJoinRequestFilter : BaseFilter<TeamJoinRequest>
    {
        public Maybe<Guid> TeamId { get; set; }
        public Maybe<Guid> UserToJoinId { get; set; }
        public Maybe<JoinRequestState> State { get; set; } 
        public override IQueryable<TeamJoinRequest> EnrichQuery(IQueryable<TeamJoinRequest> query)
        {
            if(TeamId.HasValue)
                query = query.Where(q=>q.Team.Id == TeamId.Value);
            if(UserToJoinId.HasValue)
                query = query.Where(q=>q.User.Id == UserToJoinId.Value);
            if (State.HasValue)
            {
                if (State.Value == JoinRequestState.None)
                    query = query.Where(q => q.State == null);
                else
                    query = query.Where(q => q.State == State.Value);
            }
            return query;
        }
    }
}
