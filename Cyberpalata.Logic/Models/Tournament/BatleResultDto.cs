namespace Cyberpalata.Logic.Models.Tournament
{
    public class BatleResultDto
    {
        public virtual TeamDto Winner { get; set; }
        public int RoundNumber { get; set; }
        public DateTime Date { get; set; }
        public BatleDto Batle { get; set; }
    }
}
