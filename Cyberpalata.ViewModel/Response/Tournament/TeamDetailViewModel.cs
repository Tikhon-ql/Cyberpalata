namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TeamDetailViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CaptainName { get; set; }
        public List<TeamMemberViewModel> Members { get; set; }
    }
}
