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
        public TeamDto? FirstTeam { get; set; }
        public TeamDto? SecondTeam { get; set; }
        //public BatleResultDto? Result { get;set; }
        public int RoundNumber { get; set; }
    }
}
