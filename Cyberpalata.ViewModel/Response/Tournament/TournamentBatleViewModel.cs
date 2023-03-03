namespace Cyberpalata.ViewModel.Response.Tournament
{
    public class TournamentBatleViewModel
    {
        public Guid BatleId { get; set; }
        public Guid FirstTeamId { get; set; }
        public Guid SecondTeamId { get; set; }
        public string FirstTeamName { get; set; } = String.Empty;
        public string SecondTeamName { get; set; } = String.Empty;
        public int RoundNumber { get; set; } = 0;
    }
}
