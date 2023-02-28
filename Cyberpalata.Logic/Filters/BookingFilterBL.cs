using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class BookingFilterBL : BaseFilterBL
    {
        public Maybe<bool> IsActual { get; set; }
        public Maybe<Guid> UserId { get; set; }
    }
}
