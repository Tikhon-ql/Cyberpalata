using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamMemberDto
    {
        public UserDto Member { get; set; }
        public TeamDto Team { get; set; }
        public bool IsCaptain { get; set; }
        public List<TeamJoinRequestDto> JoinRequests { get; set; }     
    }
}
