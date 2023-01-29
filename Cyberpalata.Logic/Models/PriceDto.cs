namespace Cyberpalata.Logic.Models
{
    public class PriceDto
    {
        public PriceDto()
        {
            Hours = 0;
            Cost = 0;
        }
        public PriceDto(int hours, int cost)
        {
            Hours = hours;
            Cost = cost;
        }

        public int Hours { get; set; }
        public int Cost { get; set; }
    }
}
