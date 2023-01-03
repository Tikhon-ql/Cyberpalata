using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Rooms
{
    public class GameConsoleRoomDto : RoomDto
    {
        public virtual List<GameConsole> Consoles { get; set; } = new();
    }
}
