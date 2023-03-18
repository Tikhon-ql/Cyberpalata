using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class TeamRecrutingStateChangeViewModel
    {
        public Guid TeamId { get; set; }
        public bool State { get; set; }
    }
}
