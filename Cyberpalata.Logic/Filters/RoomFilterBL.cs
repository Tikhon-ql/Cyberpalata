using CSharpFunctionalExtensions;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Filters
{
    public class RoomFilterBL : BaseFilterBL
    {
        public Maybe<string> SearchName { get;set; }
        public Maybe<int> FreeSeatsCount { get; set; }
        public Maybe<int> FreeSeatsInRowCount { get; set; }
        public Maybe<DateTime> Date { get; set; }
        public Maybe<int> HoursCount { get; set; }
        public Maybe<TimeSpan> Begining { get; set; }
    }
}
