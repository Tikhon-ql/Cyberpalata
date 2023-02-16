using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class BookingFilter : BaseFilter<Booking>
    {
        public Maybe<Guid> UserId { get; set; }

        public override IQueryable<Booking> EnrichQuery(IQueryable<Booking> query)
        {
            if(UserId.HasValue && UserId.Value != Guid.Empty)
                query = query.Where(b=>b.User.Id == UserId.Value);
            return query;
        }
    }
}
