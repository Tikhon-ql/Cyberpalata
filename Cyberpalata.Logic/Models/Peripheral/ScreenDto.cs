using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.Logic.Models.Peripheral
{
    public class ScreenDto : PeripheryDto
    {
        public ScreenDto(string name, double resolution, double frequency) : base(name, PeripheryType.Screen)
        {
            Resolution = resolution;
            Frequency = frequency;
        }
        public double Resolution { get; set; }
        public double Frequency { get; set; }
    }
}
