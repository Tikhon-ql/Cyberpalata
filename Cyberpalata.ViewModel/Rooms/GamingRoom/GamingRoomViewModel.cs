using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class GamingRoomViewModel
    {
        public PcInfo PcInfo { get; set; }
        public List<Periphery> Peripheries { get; set; } = new();
        public List<Price> Prices { get; set; } = new();
    }
}
