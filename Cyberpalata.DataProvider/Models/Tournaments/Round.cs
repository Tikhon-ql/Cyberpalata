using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Round : BaseEntity
    {
        public int Number { get; set; }
        public DateTime Date { get;set; }
        public int TeamsMaxCount { get;set; }
        public virtual List<Batle> Batles { get; set; }
    }
}
