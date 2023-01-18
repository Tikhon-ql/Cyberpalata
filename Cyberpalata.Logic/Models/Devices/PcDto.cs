using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Logic.Models.Devices
{
    public class PcDto : DeviceDto
    {
        [Required][MaxLength(50)] public string Gpu { get; set; }
        [Required][MaxLength(50)] public string Cpu { get; set; }
        [Required][MaxLength(50)] public string Ram { get; set; }
        [Required][MaxLength(50)] public string Hdd { get; set; }
        [Required][MaxLength(50)] public string Ssd { get; set; }
    }
}
