using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TeamBatleViewModel
    {
        public string FirstTeamName { get; set; }
        public int FirstTeamScore { get; set; }
        public string SecondTeamName { get; set; }
        public int SecondTeamScore { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
