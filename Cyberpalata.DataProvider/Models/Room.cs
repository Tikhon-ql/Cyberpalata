using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Room : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual RoomType Type { get; set; }
        public bool IsVip { get; set; }
        public virtual List<Seat> Seats { get; set; } = new();
        public virtual List<Booking> Bookings { get; set; } = new();
        public virtual List<GameConsole> Consoles { get; set; } = new();
        public virtual Pc Pc { get; set; }
        public virtual List<Periphery> Peripheries { get; set; } = new();
    }
}
