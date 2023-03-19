using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<TeamMember>? Members { get; set; }
        public virtual List<Tournament>? Tournaments { get; set; }
        public int WinCount { get; set; }
        public bool IsRecruting { get; set; }
    }
}
