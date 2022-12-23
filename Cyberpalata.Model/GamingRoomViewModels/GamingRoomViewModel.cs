using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.GamingRoomViewModels
{
    public class GamingRoomViewModel
    {
        //public string Name { get; set; }
        public virtual List<string> Prices { get; set; } = new();
        //public virtual List<string> AllSeats { get; set; } = new();
        //public virtual List<string> FreeSeats { get; set; } = new();
        public List<string> Devices { get; set; }
        public List<string> Peripheries { get; set; }

        public string Type { get; set; } //= GamingModuleType.Common;
    }
}
