using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentDetailedViewModel
    {
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        //public List<PhaseViewModel> Phases { get; set; } = new();
        public List<TournamentBatleViewModel> Batles { get; set; } = new();
        //public SortedSet<PhaseViewModel> Tree { get; set; } = new();
        //public TournamentTeamViewModel RootTeam { get; set; }

        //public int TeamsMaxCount { get; set; }

        //public List<RoundViewModel> Rounds { get; set; }
    }
}
