using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class RoundViewModel
    {
        public int Number { get; set; }
        public List<TeamBatleViewModel> Batles { get; set; }
    }
}
