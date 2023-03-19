using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class TeamFilterBL : BaseFilterBL
    {
        public Maybe<Guid> CaptainId { get; set; }
        public Maybe<Guid> MemberId { get; set; }
        public Maybe<bool> IsRecruting { get; set; }
        public Maybe<bool> IsTop { get; set; }
    }
}
