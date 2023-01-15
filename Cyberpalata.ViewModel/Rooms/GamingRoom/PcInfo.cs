using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class PcInfo
    {
        //public PcInfo(string gpu, string cpu, string ram, string hdd, string ssd)
        //{
        //    Gpu = gpu;
        //    Cpu = cpu;
        //    Ram = ram;
        //    Hdd = hdd;
        //    Ssd = ssd;
        //}

        //public string Gpu { get; set; }
        //public string Cpu { get; set; }
        //public string Ram { get; set; }
        //public string Hdd { get; set; }
        //public string Ssd { get; set; }

        public PcInfo(string type, string name)
        {
            Type = type;
            Name = name;
        }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
