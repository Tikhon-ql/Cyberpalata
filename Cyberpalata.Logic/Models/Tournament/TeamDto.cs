namespace Cyberpalata.Logic.Models.Tournament
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TeamMemberDto> Members { get; set; } = new();
        public List<TournamentDto> Tournaments { get; set; } = new();
        public bool IsRecruting { get; set; }
        public int WinCount { get; set; }
        public bool IsApproved { get; set; }
        public TeamMemberDto Captain => Members.FirstOrDefault(m => m.IsCaptain);
    }
}
