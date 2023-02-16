using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TeamDetailViewModel
    {
        public string Name { get; set; }
        public string CaptainName { get; set; }
        public List<string> Members { get; set; }
    }
}
