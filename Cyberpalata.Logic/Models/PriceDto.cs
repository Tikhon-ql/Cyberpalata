namespace Cyberpalata.Logic.Models
{
    public class PriceDto
    {
        public PriceDto(int hours, decimal cost)
        {
            Hours = hours;
            Cost = cost;
        }

        public PriceDto(string value)
        {
            var strs = value.Split(':');
            Hours = int.Parse(strs[0]);
            Cost = decimal.Parse(strs[1]);
        }

        public Guid Id { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
