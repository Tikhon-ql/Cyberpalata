namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class BatleResult : BaseEntity
    {
        public virtual Team Winner { get; set; }
        public int RoundNumber { get; set; }
        public DateTime Date { get; set; }
        public virtual Batle Batle { get; set; }
    }
}
