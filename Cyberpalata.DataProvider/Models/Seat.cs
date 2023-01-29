using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Seat
    {
        [Key] 
        [Required] 
        public Guid Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required] 
        public virtual Room Room { get; set; }
    }
}
