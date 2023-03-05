using CSharpFunctionalExtensions;
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
        public override IQueryable<TeamJoinRequest> EnrichQuery(IQueryable<TeamJoinRequest> query)
        {
            if(TeamId.HasValue)
                query = query.Where(q=>q.Team.Id == TeamId.Value);
            return query;
        }
    }
}
