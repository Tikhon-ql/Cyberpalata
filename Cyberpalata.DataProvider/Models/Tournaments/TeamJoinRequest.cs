using Cyberpalata.DataProvider.Models.Identity;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class TeamJoinRequest : BaseEntity
    {
        public virtual Team Team { get; set; }
        public virtual User User { get; set; }
        //public bool  { get;set; } add enum state InProgress Accepted Rejected
    }
}
