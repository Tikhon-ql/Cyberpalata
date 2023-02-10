
namespace Cyberpalata.Logic.Models.Seats
{
    public class SeatsGettingRequest
    {
        public Guid RoomId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Begining { get; set; }
        public int HoursCount { get; set; }
    }
}
