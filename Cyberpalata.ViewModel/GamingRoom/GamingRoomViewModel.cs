using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.GamingRoom
{
    public class GamingRoomViewModel
    {
        public List<PcInfo> PcInfos { get; set; } = new();
        public List<Periphery> Peripheries { get; set; } = new();
        public List<Price> Prices { get; set; } = new();
    }
}
