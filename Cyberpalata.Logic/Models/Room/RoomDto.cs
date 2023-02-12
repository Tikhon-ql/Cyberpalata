using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using Cyberpalata.Logic.Models.Seats;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Room
{
    public class RoomDto
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public bool IsVip { get; set; } = false;
        public List<SeatDto> Seats { get; set; } = new();
        public List<BookingDto> Bookings { get; set; } = new();
        public List<GameConsoleDto> Consoles { get; set; } = new();
        public List<PeripheryDto> Peripheries { get; set; } = new();
    }
}
