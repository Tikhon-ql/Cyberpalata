using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class GamingRoom
    {
        [Key] public Guid Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        [Required] public GamingRoomType Type { get; set; }
        public virtual List<Price> Prices { get; set; }
        public virtual List<Seat> Seats { get; set; }
        public virtual List<Periphery> Peripheries { get; set; }
        public virtual List<Pc> Pcs { get; set; }
    }
}
