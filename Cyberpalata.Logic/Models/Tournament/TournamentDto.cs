namespace Cyberpalata.Logic.Models.Tournament
{
    public class TournamentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RoundCount { get; set; }
        public TeamDto Winner { get; set; }
        public List<BatleDto> Batles { get; set; }
        public TimeSpan Begining { get; set; }
        //public List<BatleResultDto> BatleResults { get; set; }
        public int TeamsCount
        {
            get
            {
                int count = 0;
                foreach(var batle in Batles.Where(b=>b.RoundNumber == 0).ToList())
                {
                    if (batle.FirstTeam != null)
                        count++;
                    if (batle.SecondTeam != null)
                        count++;
                }
                return count;
            }
        }
    }
}
