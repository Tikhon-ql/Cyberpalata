using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class GameConsole : Device
    {
        public GameConsole(string consoleName)
        {
            ConsoleName = consoleName;
        }

        public string ConsoleName { get; set; }
    }
}
