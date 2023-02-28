using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentTeamViewModel
    {
        public string Name { get; set; } = String.Empty;
        public List<TournamentTeamViewModel> Children { get; set; } = new();
    }
}
