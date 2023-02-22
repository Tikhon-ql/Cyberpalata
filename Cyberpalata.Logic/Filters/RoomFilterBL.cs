using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Filters
{
    public class RoomFilterBL : BaseFilterBL
    {
        public Maybe<RoomType> Type { get; set; }
        public Maybe<bool> IsVip { get; set; }
    }
}
