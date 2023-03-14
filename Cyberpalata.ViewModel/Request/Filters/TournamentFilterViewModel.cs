using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Filters
{
    public class TournamentFilterViewModel
    {
        public string? SearchName { get; set; }
        public bool AllTournaments { get; set; }
        public bool ActualTournaments { get; set; }
        public int Page { get; set; }
    }
}
