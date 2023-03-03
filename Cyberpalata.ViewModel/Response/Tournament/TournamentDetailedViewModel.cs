namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentDetailedViewModel
    {
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public List<TournamentBatleViewModel> Batles { get; set; } = new();
    }
}
