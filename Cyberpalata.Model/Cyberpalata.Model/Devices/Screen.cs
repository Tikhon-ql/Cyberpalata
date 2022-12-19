using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Devices
{
    public class Screen : Device
    {
        public Screen(string name, double resolution, double frequency) : base(name)
        {
            Resolution = resolution;
            Frequency = frequency;
        }

        public double Resolution { get; set; }
        public double Frequency { get; set; }
    }
}
