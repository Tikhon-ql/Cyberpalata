namespace Cyberpalata.DataProvider.Models.Tournaments
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RoundsCount { get; set; }
        public virtual Team? Winner { get; set; }
        public virtual List<Batle>? Batles { get; set; }
        //public virtual List<BatleResult> BatleResults { get; set; } 
        public bool IsGone { get; set; }
    }
}
