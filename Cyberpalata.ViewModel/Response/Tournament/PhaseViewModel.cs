using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class PhaseViewModel
    {
        public string ParentTeamName { get; set; }
        public string FirstChildTeamName { get; set; }
        public string SecondChildTeamName { get; set; }
        public PhaseViewModel LeftTeam { get; set; }
        public PhaseViewModel RightTeam { get; set; }

        public int RoundNumber { get; set; }
    }
}
