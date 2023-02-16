using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TeamMemberDto> Members { get; set; } = new();
        public List<TournamentDto> Tournaments { get; set; } = new();
        public bool IsHiring { get; set; }
        public TeamMemberDto Captain => Members.FirstOrDefault(m => m.IsCaptain);
    }
}
