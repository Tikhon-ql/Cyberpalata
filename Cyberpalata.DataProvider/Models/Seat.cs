using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Seat : BaseEntity
    {
        //[Key] 
        //[Required] 
        //public Guid Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
