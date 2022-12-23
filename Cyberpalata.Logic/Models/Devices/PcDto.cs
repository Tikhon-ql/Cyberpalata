using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Devices
{
    public class PcDto : DeviceDto
    {
        public PcDto(string cpu, string gpu, int ssd, int hdd, int ramCount, string ramName)
        {
            Cpu = cpu;
            Gpu = gpu;
            Ssd = ssd;
            Hdd = hdd;
            RamCount = ramCount;
            RamName = ramName;
        }

        public string Cpu { get; set; }
        public string Gpu { get; set; }

        public int Ssd { get; set; }
        public int Hdd { get; set; }

        public int RamCount { get; set; }
        public string RamName { get; set; }
    }
}
