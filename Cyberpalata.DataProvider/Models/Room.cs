using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Room
    {
        [Key] public Guid Id { get; set; }
        [Required] [MaxLength(50)] public string Name { get; set; }
        [Required] public RoomType Type { get; set; }
        [Required] public virtual List<Price> Prices { get; set; } = new();
        [Required] public virtual List<Seat> Seats { get; set; } = new();
    }
}
