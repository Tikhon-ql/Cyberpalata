using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class AddTeamMemberViewModel
    {
        public string NewMemberEmail { get; set; }
        public Guid TeamId { get; set; }
    }
}
