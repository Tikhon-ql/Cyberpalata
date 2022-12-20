using Cyberpalata.DataProvider.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Screen : Periphery
    {
        public Screen(string name, double resolution, double frequency) : base(name, PeripheryType.Screen)
        {
            Resolution = resolution;
            Frequency = frequency;
        }

        public double Resolution { get; set; }
        public double Frequency { get; set; }
    }
}
