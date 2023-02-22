using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class BookingFilterBL : BaseFilterBL
    {
        public Maybe<Guid> UserId { get; set; }
    }
}
