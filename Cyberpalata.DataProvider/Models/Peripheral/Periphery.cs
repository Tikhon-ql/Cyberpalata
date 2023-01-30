using System.ComponentModel.DataAnnotations;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Periphery
    {
        [Key] 
        [Required] 
        public Guid Id { get; set; }
        [MaxLength(50)] 
        [Required] 
        public string? Name { get; set; }
        [Required]
        public virtual PeripheryType Type { get; set; }
        public virtual Room GamingRoom { get; set; }
    }
}
