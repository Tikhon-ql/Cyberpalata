using Cyberpalata.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Room
    {
        [Key] public Guid Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        [Required] public RoomType Type { get; set; }
        public bool IsVip { get; set; }
        public virtual List<Price> Prices { get; set; } = new List<Price>();
        public virtual List<Seat> Seats { get; set; } = new List<Seat>();
        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
