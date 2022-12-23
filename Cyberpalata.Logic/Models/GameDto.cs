using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models
{
    public class GameDto
    {
        public GameDto(string gameName)
        {
            GameName = gameName;
        }

        public Guid Id { get; set; }
        public string GameName { get; set; }
    }
}
