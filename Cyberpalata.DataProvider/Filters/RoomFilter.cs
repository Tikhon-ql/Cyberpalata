using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Filters
{
    public class RoomFilter : BaseFilter<Room>
    {
        public Maybe<RoomType> Type { get; set; }
        public Maybe<bool> IsVip { get; set; }

        public override IQueryable<Room> EnrichQuery(IQueryable<Room> query)
        {
            if (Type.HasValue)
                query = query.Where(q => q.Type == Type.Value);
            if(IsVip.HasValue)
                query = query.Where(q=>q.IsVip == IsVip.Value);
            return query;
        }
    }
}
