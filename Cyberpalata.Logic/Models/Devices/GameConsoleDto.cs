using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Devices
{
    public class GameConsoleDto : DeviceDto
    {
        public GameConsoleDto(string consoleName)
        {
            ConsoleName = consoleName;
        }

        public string ConsoleName { get; set; }
    }
}
