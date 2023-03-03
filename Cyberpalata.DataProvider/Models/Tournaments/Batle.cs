namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Batle : BaseEntity
    {
        public DateTime Date { get; set; }
        public virtual Team? FirstTeam { get; set; }
        public virtual Team? SecondTeam { get; set;}
        public virtual Tournament Tournament { get;set; }
        public int RoundNumber { get; set; }
    }
}
