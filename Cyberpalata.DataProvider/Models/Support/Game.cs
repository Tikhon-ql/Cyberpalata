using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Support
{
    public class Game
    {
        public Game(string gameName)
        {
            GameName = gameName;
        }

        public Guid Id { get; set; }
        public string GameName { get; set; }
    }
}
