using Cyberpalata.Logic.Models.Identity;

namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamJoinRequestDto
    {
        public Guid TeamId { get; set; }
        public UserDto User { get; set; }
    }
}
