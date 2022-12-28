using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class GamingRoom : Room
    {
        [Required] public List<Pc> Pcs { get; set; } = new(); 
        [Required] public List<Periphery> Peripheries { get; set; } = new();
        [Required] public GamingRoomType Type { get; set; } = GamingRoomType.Common;
    }
}
