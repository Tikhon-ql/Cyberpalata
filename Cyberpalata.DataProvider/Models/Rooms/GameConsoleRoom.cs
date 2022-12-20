using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Rooms
{
    public class GameConsoleRoom : Room
    {
        public GameConsoleRoom() : base("Game console room")
        {
        }

        public virtual List<GameConsole> Consoles { get; set; } = new();
    }
}
