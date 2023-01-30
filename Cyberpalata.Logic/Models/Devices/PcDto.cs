using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Devices
{
    public class PcDto
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Gpu { get; set; } = String.Empty;
        [MaxLength(50)] 
        public string Cpu { get; set; } = String.Empty;
        [MaxLength(50)] 
        public string Ram { get; set; } = String.Empty;
        [MaxLength(50)] 
        public string Hdd { get; set; } = String.Empty;
        [MaxLength(50)] 
        public string Ssd { get; set; } = String.Empty;
    }
}
