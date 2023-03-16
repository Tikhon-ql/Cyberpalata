using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Peripheral;

namespace Cyberpalata.DataProvider.Filters
{
    public class PeripheriesFilter : BaseFilter<Periphery>
    {
        public Maybe<Guid> RoomId { get; set; }
        public override IQueryable<Periphery> EnrichQuery(IQueryable<Periphery> query)
        {
            if(RoomId.HasValue)
                query = query.Where(q=>q.GamingRoom.Id == RoomId.Value);
            return query;
        }
    }
}
