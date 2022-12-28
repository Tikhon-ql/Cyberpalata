using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class Room
    {
        [Key] public Guid Id { get; set; }
        [MaxLength(50)] public string? Name { get; set; }

        [Required] public virtual List<Price> Prices { get; set; } = new();
        [Required] public virtual List<Seat> Seats { get; set; } = new();
        //[Required] public virtual List<Seat> FreeSeats { get; set; } = new();
    }
}
