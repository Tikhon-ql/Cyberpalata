using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Filters
{
    public class BookingFilter : BaseFilter<Booking>
    {
        public Maybe<bool> IsActual { get; set; }
        public Maybe<Guid> UserId { get; set; }

        public override IQueryable<Booking> EnrichQuery(IQueryable<Booking> query)
        {
            if(IsActual.HasValue)
            {
                if (IsActual.Value)
                    query = query.Where(b => b.Date > DateTime.UtcNow);
                else
                    query = query.Where(b=> b.Date < DateTime.UtcNow);
            }
            if(UserId.HasValue && UserId.Value != Guid.Empty)
                query = query.Where(b=>b.User.Id == UserId.Value);
            return query;
        }
    }
}
