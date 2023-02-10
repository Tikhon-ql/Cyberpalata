using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Seats
{
    public class SeatsGettingRequest
    {
        [Required]
        public Guid RoomId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
    }
}
