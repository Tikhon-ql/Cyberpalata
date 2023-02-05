using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Models.Booking;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using Cyberpalata.Logic.Models.Seats;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models
{
    public class RoomDto
    {
        [Key] 
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        //[Required] public RoomType Type { get; set; } = new RoomType(0, "None");
        public bool IsVip { get; set; } = false;
        public List<PriceDto> Prices { get; set; } = new();
        public List<SeatDto> Seats { get; set; } = new();
        public List<BookingDto> Bookings { get; set; } = new();
        public List<GameConsoleDto> Consoles { get; set; } = new();
        //public PcDto Pc { get; set; } = new();
        public List<PeripheryDto> Peripheries { get; set; } = new();
    }
}
