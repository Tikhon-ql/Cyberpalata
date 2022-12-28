using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class Pc : Device
    {
        [MaxLength(50)][Required] public string? Cpu { get; set; }

        [MaxLength(50)][Required] public string? Gpu { get; set; }

        [Required] public int Ssd { get; set; }

        [Required] public int Hdd { get; set; }

        [Required] public int RamCount { get; set; }

        [MaxLength(50)][Required] public string? RamName { get; set; }

    }
}
