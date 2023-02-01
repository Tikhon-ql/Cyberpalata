using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Price
    {
        [Key] 
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
    }
}
