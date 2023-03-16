using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Filters
{
    public class RoomFilter : BaseFilter<Room>
    {
        public Maybe<string> SearchName { get; set; }
        public Maybe<int> FreeSeatsCount { get; set; }
        public Maybe<int> FreeSeatsInRowCount { get; set; }
        public Maybe<DateTime> Date { get; set; }
        public Maybe<int> HoursCount { get; set; }
        public Maybe<TimeSpan> Begining { get; set; }

        public override IQueryable<Room> EnrichQuery(IQueryable<Room> query)
        {
            if (SearchName.HasValue)
                query = query.Where(q => q.Name.Contains(SearchName.Value));
            if (FreeSeatsCount.HasValue && Date.HasValue && HoursCount.HasValue && Begining.HasValue)
            {
                query = query.ToList().Where(q => HasMoreFreeSeatsThan(FreeSeatsCount.Value, q) == true).AsQueryable();
            }
            var list = query.ToList();
            return query;
        }

        private bool HasMoreFreeSeatsThan(int freeSeatsCount, Room room)
        {
            int freeSeats = 0;

            var roomSeats = room.Seats;
            if (roomSeats.Count == 0)
                return false;

            var actualRoomBookings = room.Bookings.Where(b => b.Date >= DateTime.UtcNow).ToList();

            //TODO: PUSH IT INTO SEPARATE METHODE
            var bookings = actualRoomBookings
                .Where(b => (b.Date == Date.Value
                && ((Begining.Value <= b.Begining
                    && Date.Value.Add(Begining.Value).AddHours(HoursCount.Value) > b.Date.Add(b.Begining))
                || (b.Begining <= Begining.Value
                    && Date.Value.Add(Begining.Value) < b.Date.Add(b.Begining).AddHours(b.HoursCount))))).ToList();
            foreach (var seat in roomSeats)
            {
                var isSeatFree = bookings.FirstOrDefault(b => b.Seats.FirstOrDefault(s => s.Id == seat.Id) != null) == null;
                if (isSeatFree)
                {
                    freeSeats++;
                }
            }
            if (freeSeats >= freeSeatsCount)
                return true;
            return false;
        }
    }
}
