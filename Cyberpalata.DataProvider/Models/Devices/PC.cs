using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class Pc
    {
        [Key]
        [Required] 
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Gpu { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Cpu { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Ram { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Hdd { get; set; }
        [Required]
        [MaxLength(50)] 
        public string Ssd { get; set; }
        public virtual Room GamingRoom { get; set; }
    }
}
