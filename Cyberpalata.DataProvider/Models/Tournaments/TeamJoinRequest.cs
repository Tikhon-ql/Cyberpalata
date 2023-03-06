using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class TeamJoinRequest : BaseEntity
    {
        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
        public virtual JoinRequestState? State { get; set; }
    }
}
