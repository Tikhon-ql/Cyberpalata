using Cyberpalata.Common.Enums;
using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamJoinRequestDto
    {
        public TeamDto Team { get; set; }
        public UserDto User { get; set; }
        public JoinRequestState State { get; set; }
    }
}
