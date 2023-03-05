using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Filters
{
    public class TeamFilter : BaseFilter<Team>
    {
        public Maybe<Guid> CaptainId { get; set; }
        public Maybe<bool> IsHiring { get; set; }

        public override IQueryable<Team> EnrichQuery(IQueryable<Team> query)
        {
            if (CaptainId.HasValue && CaptainId.Value != Guid.Empty)
                query = query.ToList().Where(q => q.Members.FirstOrDefault(m => m.IsCaptain && m.MemberId == CaptainId.Value) != null).ToList().AsQueryable();
            if (IsHiring.HasValue)
                query = query.Where(q => q.IsHiring == IsHiring.Value);
            return query.ToList().AsQueryable();
        }
    }
}
