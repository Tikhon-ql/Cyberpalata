using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Devices
{
    //TODO: Have to store gaming room type
    public class Pc
    {
        [Key][Required] public Guid Id { get; set; }
        //[Required] [MaxLength(20)] public string Name { get; set; }
        //[Required] [MaxLength(50)] public string Value { get; set; }
        [Required][MaxLength(50)] public string Gpu { get; set; }
        [Required][MaxLength(50)] public string Cpu { get; set; }
        [Required][MaxLength(50)] public string Ram { get; set; }
        [Required][MaxLength(50)] public string Hdd { get; set; }
        [Required][MaxLength(50)] public string Ssd { get; set; }
        [ForeignKey("GamingRoomId")]
        [Required] public virtual Room GamingRoom { get; set; }
    }
}
