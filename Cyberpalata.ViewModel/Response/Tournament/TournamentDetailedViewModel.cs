using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentDetailedViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int TeamsMaxCount { get; set; }
        public List<TeamBatleViewModel> Batles { get; set; }
    }
}
