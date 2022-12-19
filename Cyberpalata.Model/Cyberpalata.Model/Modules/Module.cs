using Cyberpalata.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Model.Devices.Furniture;

namespace Cyberpalata.Model.Modules
{
    public class Module
    {
        public Module(string name, Furniture furniture)
        {
            Name = name;
            Furniture = furniture;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Furniture Furniture { get; set; }

        public virtual List<Price> Prices { get; set; } = new();
        public virtual List<Seat> AllSeats { get; set; } = new();
        public virtual List<Seat> FreeSeats { get; set; } = new();
    }
}
