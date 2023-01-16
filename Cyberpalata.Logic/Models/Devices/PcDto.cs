using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
