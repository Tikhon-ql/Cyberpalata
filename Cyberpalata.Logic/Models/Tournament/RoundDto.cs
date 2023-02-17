using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class RoundDto
    {
        public int RoundTeamsMaxCount { get;set; }
        public List<BatleDto> Batles { get; set; }
    }
}
