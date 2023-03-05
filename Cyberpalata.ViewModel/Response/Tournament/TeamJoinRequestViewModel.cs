using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TeamJoinRequestViewModel
    {
        public Guid UserId { get; set; }
        public Guid TeamId { get;set; }
        public string Username { get; set; }
        public string Usersurname { get; set; }
    }
}
