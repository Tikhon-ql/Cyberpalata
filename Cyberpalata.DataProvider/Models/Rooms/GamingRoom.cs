using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Models.Enums;
using Cyberpalata.DataProvider.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class GamingRoom : Room
    {
        public GamingRoom() : base("Gaming room")
        {

        }
        public List<Device> Devices { get; set; }

        public List<Periphery> Peripheries { get; set; }

        public GamingModuleType Type { get; set; } = GamingModuleType.Common;

    }
}
