using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class TournamentFilterBL : BaseFilterBL
    {
        public Maybe<Guid> CaptainId { get;set; }
        public Maybe<bool> IsActual { get; set; }
    }
}
