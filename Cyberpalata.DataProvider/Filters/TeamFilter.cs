using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Filters
{
    public class TeamFilter : BaseFilter<Team>
    {
        public Maybe<Guid> CaptainId { get; set; }
        public Maybe<Guid> MemberId { get; set; }
        public Maybe<bool> IsRecruting { get; set; }
        public Maybe<bool> IsTop { get; set; }

        public override IQueryable<Team> EnrichQuery(IQueryable<Team> query)
        {
            if (CaptainId.HasValue && CaptainId.Value != Guid.Empty)
                query = query.ToList().Where(q => q.Members.FirstOrDefault(m => m.IsCaptain && m.MemberId == CaptainId.Value) != null).ToList().AsQueryable();
            if(MemberId.HasValue && CaptainId.HasNoValue)
            {
                query = query.Where(q =>
                    q.Members.FirstOrDefault(m => m.Member.Id == MemberId.Value) != null);
            }
            if (IsRecruting.HasValue)
                query = query.Where(q => q.IsRecruting == IsRecruting.Value);
            if(IsTop.HasValue)
            {
                if(IsTop.Value)
                {
                    query = query.OrderByDescending(query=>query.WinCount);
                }
            }
            return query.ToList().AsQueryable();
        }
    }
}
