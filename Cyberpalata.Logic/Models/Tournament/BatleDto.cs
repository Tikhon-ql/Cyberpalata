using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class BatleDto
    {
        public DateTime Date { get; set; }
        public virtual TeamDto? FirstTeam { get; set; }
        public virtual TeamDto? SecondTeam { get; set; }
    }
}
