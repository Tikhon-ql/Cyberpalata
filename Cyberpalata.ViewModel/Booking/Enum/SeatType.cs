using Cyberpalata.Common.Enums;

namespace Cyberpalata.ViewModel.Booking.Enum
{
    public class SeatType : Enumeration
    {
        public static SeatType Free = new SeatType(1, "Free");
        public static SeatType UsersSeat = new SeatType(2, "UsersSeat");
        public SeatType(int id, string name) : base(id, name)
        {
        }
    }
}
