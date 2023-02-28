using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class SetWinnerViewModel
    {
        public Guid TournamentId { get; set; }
        public Guid BatleId { get; set; }
        public Guid WinnerId { get; set; }
    }
}
