using Cyberpalata.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Screen : Periphery
    {
        public double Resolution { get; set; }
        public double Frequency { get; set; }
    }
}
