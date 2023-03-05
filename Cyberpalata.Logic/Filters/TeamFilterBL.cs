using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class TeamFilterBL : BaseFilterBL
    {
        public Maybe<Guid> CaptainId { get; set; }
        public Maybe<bool> IsHiring { get; set; }
    }
}
