namespace Cyberpalata.ViewModel.Rooms
{
    public class PriceViewModel
    {
        public PriceViewModel(int hours, decimal cost)
        {
            Hours = hours;
            Cost = cost;
        }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
