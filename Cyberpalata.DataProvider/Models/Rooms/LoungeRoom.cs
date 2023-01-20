using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class LoungeRoom
    {
        [Key] public Guid Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        //public virtual List<Price> Prices { get; set; }
        //public virtual List<Seat> Seats { get; set; }
        public virtual List<MenuItem> Menu { get; set; }
    }
}
