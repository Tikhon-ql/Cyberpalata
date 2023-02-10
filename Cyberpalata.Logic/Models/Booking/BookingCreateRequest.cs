using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Booking
{
    public class BookingCreateRequest
    {
        public Guid RoomId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public List<int> Seats { get; set; } = new();
    }
}
