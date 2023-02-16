using Cyberpalata.Common.Enums;

namespace Cyberpalata.ViewModel.Response.Booking.Enum
{
    public class SeatType : Enumeration
    {
        public static SeatType Free = new SeatType(1, "Free");
        public static SeatType IsTaken = new SeatType(2, "IsTaken");
        public static SeatType UsersSeat = new SeatType(3, "UsersSeat");
        public SeatType(int id, string name) : base(id, name)
        {
        }
    }
}
