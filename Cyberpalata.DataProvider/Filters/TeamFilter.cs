using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class TeamFilter : BaseFilter<Team>
    {
        public Maybe<Guid> UserId { get; set; }
        public Maybe<bool> IsHiring { get; set; }

        public override IQueryable<Team> EnrichQuery(IQueryable<Team> query)
        {
            if (UserId.HasValue && UserId.Value != Guid.Empty)
                query = query.ToList().Where(q => q.Members.FirstOrDefault(m => m.IsCaptain && m.MemberId == UserId) != null).ToList().AsQueryable();
            if (IsHiring.HasValue)
                query = query.Where(q => q.IsHiring == IsHiring.Value);
            return query.ToList().AsQueryable();
        }
    }
}
