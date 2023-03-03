using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class TeamMember : BaseEntity
    {
        [Required]
        public Guid MemberId { get; set; }
        [Required]
        [ForeignKey("MemberId")]
        public virtual User Member { get; set; }
        [Required]
        public Guid TeamId { get; set; }
        [Required]
        [ForeignKey("TeamId")]
        public virtual Team Team { get;set; }
        public bool IsCaptain { get; set; }
        public virtual List<TeamJoinRequest> JoinRequests { get; set; }
    }
}
