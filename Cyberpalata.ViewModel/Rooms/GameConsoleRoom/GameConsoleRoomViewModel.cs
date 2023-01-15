    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Rooms.GameConsoleRoom
{
    public class GameConsoleRoomViewModel
    {
        public List<string> GameConsoles { get; set; } = new();
        public List<Price> Prices { get; set; } = new();
    }
}
