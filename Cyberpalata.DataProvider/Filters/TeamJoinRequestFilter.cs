using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Filters
{
    public class TeamJoinRequestFilter : BaseFilter<TeamJoinRequest>
    {
        public Maybe<Guid> TeamId { get; set; }
        public Maybe<Guid> UserToJoinId { get; set; }
        public Maybe<List<JoinRequestState>> State { get; set; } 
        public override IQueryable<TeamJoinRequest> EnrichQuery(IQueryable<TeamJoinRequest> query)
        {
            if(TeamId.HasValue)
                query = query.Where(q=>q.Team.Id == TeamId.Value);
            if(UserToJoinId.HasValue)
                query = query.Where(q=>q.User.Id == UserToJoinId.Value);
            if (State.HasValue)
            {
                if (State.Value.Contains(JoinRequestState.None))
                    query = query.Where(q => q.State == null);
                else
                    query = query.Where(q => State.Value.Contains(q.State));
            }
            return query;
        }
    }
}
