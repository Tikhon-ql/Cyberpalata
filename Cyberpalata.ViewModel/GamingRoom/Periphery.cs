using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.ViewModel.GamingRoom
{
    public class Periphery
    {
        public string Name { get; set; }
        public PeripheryType Type { get; set; } = PeripheryType.Headphone;
    }
}
