using System.ComponentModel.DataAnnotations;

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
        public virtual Room Room { get; set; }
    }
}
