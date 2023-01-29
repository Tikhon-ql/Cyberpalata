using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public virtual RoomType Type { get; set; }
        public bool IsVip { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<Seat> Seats { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public virtual List<GameConsole> Consoles { get; set; }
        public virtual List<Pc> Pcs { get; set; }
        public virtual List<Periphery> Peripheries { get; set; }
    }
}
