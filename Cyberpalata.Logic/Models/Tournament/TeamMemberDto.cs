using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamMemberDto
    {
        public UserDto Member { get; set; }
        public TeamDto Team { get; set; }
        public bool IsCaptain { get; set; }
    }
}
