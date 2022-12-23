using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class Room
    {
        public Room(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }


        public virtual List<Price> Prices { get; set; } = new();
        public virtual List<Seat> AllSeats { get; set; } = new();
        public virtual List<Seat> FreeSeats { get; set; } = new();
    }
}
