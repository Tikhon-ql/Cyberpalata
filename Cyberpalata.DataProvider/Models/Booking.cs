using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        //public Room? Room { get; set; }
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
        public Price? Tariff { get; set; }
    }
}
