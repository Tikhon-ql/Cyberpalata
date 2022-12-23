using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class Lounge : Room
    {
        public Lounge() : base("Lounge")
        {
        }

        public virtual List<MenuItem> Menu { get; set; } = new();

    }
}
