using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Filters
{
    public class PcFilter : BaseFilter<Pc>
    {
        public Maybe<Guid> RoomId { get; set; }

        public override IQueryable<Pc> EnrichQuery(IQueryable<Pc> query)
        {
            if(RoomId.HasValue)
                query = query.Where(q=>q.RoomId == RoomId.Value);
            return query;
        }
    }
}
