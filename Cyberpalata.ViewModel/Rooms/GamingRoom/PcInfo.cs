using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class PcInfo
    {
        public PcInfo(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
