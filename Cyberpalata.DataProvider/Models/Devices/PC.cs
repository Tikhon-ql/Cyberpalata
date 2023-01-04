using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Devices
{
    //TODO: Have to store gaming room type
    public class Pc : Device    
    {
        [Required] [MaxLength(20)] public string? Name { get; set; }
        [Required] [MaxLength(50)] public string? Value { get; set; }
        [Required] Room? GamingRoom { get; set; }
    }
}
