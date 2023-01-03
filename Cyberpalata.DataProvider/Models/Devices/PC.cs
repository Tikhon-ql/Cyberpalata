using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Models.Devices
{
    //TODO: Have to store gaming room type
    public class Pc : Device    
    {
        //[MaxLength(50)][Required] public string? Cpu { get; set; }

        //[MaxLength(50)][Required] public string? Gpu { get; set; }

        //[Required] public int Ssd { get; set; }

        //[Required] public int Hdd { get; set; }

        //[Required] public int RamCount { get; set; }

        //[MaxLength(50)][Required] public string? RamName { get; set; }

        [Required] [MaxLength(20)] public string? Name { get; set; }
        [Required] [MaxLength(50)] public string? Value { get; set; }
        [Required] Room? GamingRoom { get; set; }
    }
}
