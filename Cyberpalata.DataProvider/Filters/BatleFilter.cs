using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Filters
{
    public class BatleFilter : BaseFilter<Batle>
    {
        public Maybe<bool> IsActual { get; set; }
        public Maybe<Guid> TournamentId { get; set; }
        public override IQueryable<Batle> EnrichQuery(IQueryable<Batle> query)
        {
            if(IsActual.HasValue)
            {
                if(IsActual.Value)
                    query = query.Where(q=>q.Date > DateTime.UtcNow);
                else
                    query = query.Where(q => q.Date < DateTime.UtcNow);
            }
            if(TournamentId.HasValue)
            {
                query = query.Where(q=>q.Tournament.Id == TournamentId.Value);
            }
            return query;
        }
    }
}
