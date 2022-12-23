using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.GamingRoom
{
    public class GamingRoomViewModel
    {
        public GamingRoomViewModel(string deviceCpu, string deviceGpu, int deviceSsd, int deviceHdd, int deviceRamCount, string deviceRamName)
        {
            DeviceCpu = deviceCpu;
            DeviceGpu = deviceGpu;
            DeviceSsd = deviceSsd;
            DeviceHdd = deviceHdd;
            DeviceRamCount = deviceRamCount;
            DeviceRamName = deviceRamName;
        }

        public string DeviceCpu { get; set; }
        public string DeviceGpu { get; set; }

        public int DeviceSsd { get; set; }
        public int DeviceHdd { get; set; }

        public int DeviceRamCount { get; set; }
        public string DeviceRamName { get; set; }

        public List<Periphery> Peripheries { get; set; } = new();

        public List<Price> Prices { get; set; } = new();
    }
}
