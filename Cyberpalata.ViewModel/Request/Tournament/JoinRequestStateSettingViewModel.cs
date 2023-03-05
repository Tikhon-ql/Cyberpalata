using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Tournament
{
    public class JoinRequestStateSettingViewModel
    {
        public Guid UserToJoinId { get;set; }
        public Guid TeamId { get;set; }
        public string State { get; set; }
    }
}
