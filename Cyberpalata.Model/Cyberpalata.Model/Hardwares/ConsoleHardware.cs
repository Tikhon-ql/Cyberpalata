using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Hardwares
{
    public class ConsoleHardware : Hardware
    {

        public ConsoleHardware(string consoleName)
        {
            ConsoleName = consoleName;
        }

        public string ConsoleName { get; set; }
    }
}
