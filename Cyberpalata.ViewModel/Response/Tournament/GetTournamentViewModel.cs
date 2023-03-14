namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class GetTournamentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TeamsCount { get; set; }
        public string Date { get; set; }
        public string Begining { get; set; }
        public bool IsCaptain { get; set; }
    }
}
