using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Hardwares
{
    public class PcHardware : Hardware
    {
        public PcHardware(string cPu, string gPu, int sSd, int hDd, int rAmCount, string rAmName)
        {
            Cpu = cPu;
            Gpu = gPu;
            Ssd = sSd;
            Hdd = hDd;
            RamCount = rAmCount;
            RamName = rAmName;
        }

        public string Cpu { get; set; }
        public string Gpu { get; set; }

        public int Ssd { get; set; }
        public int Hdd { get; set; }

        public int RamCount { get; set; }
        public string RamName { get; set; }

    }
}
