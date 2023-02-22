namespace Cyberpalata.Logic.Filters
{
    public class TeamFilterBL : BaseFilterBL
    {
        public Guid UserId { get; set; } = Guid.Empty;
        public bool IsHiring { get; set; }
    }
}
