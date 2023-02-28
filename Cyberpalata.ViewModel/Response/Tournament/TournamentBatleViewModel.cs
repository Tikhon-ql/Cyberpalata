using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentBatleViewModel
    {
        public Guid BatleId { get; set; }
        public Guid FirstTeamId { get; set; }
        public Guid SecondTeamId { get; set; }
        public string FirstTeamName { get; set; } = String.Empty;
        public string SecondTeamName { get; set; } = String.Empty;
        public int RoundNumber { get; set; } = 0;
        //public TournamentBatleViewModel ParentBatle { get; set; } = new();
        //public TournamentBatleViewModel LeftBatle { get; set; } = new();
        //public TournamentBatleViewModel RightBatle { get; set; } = new();
    }
}
