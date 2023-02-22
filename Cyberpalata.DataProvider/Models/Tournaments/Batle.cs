using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Batle : BaseEntity
    {
        //public DateTime Date { get; set; }
        public virtual Team? FirstTeam { get; set; }
        public virtual Team? SecondTeam { get; set;}
        //public int FirstTeamScore { get; set; }
        //public int SecondTeamScore { get; set;}
    }
}
