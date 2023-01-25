using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models
{
    public class RoomDto
    {
        [Key] public Guid Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        [Required] public RoomType Type { get; set; }
        public bool IsVip { get; set; }
        public virtual List<PriceDto> Prices { get; set; }
        public virtual List<SeatDto> Seats { get; set; }
        public virtual List<BookingDto> Bookings { get; set; }
    }
}
