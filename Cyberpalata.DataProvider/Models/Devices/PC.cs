using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class Pc : Device
    {
        public string Cpu { get; set; }
        public string Gpu { get; set; }

        public int Ssd { get; set; }
        public int Hdd { get; set; }

        public int RamCount { get; set; }
        public string RamName { get; set; }

    }
}
