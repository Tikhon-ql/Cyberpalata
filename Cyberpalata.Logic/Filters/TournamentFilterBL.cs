using CSharpFunctionalExtensions;

namespace Cyberpalata.Logic.Filters
{
    public class TournamentFilterBL : BaseFilterBL
    {
        public Maybe<string> SearchName { get; set; }
        public Maybe<Guid> CaptainId { get;set; }
        public Maybe<bool> IsActual { get; set; }
    }
}
