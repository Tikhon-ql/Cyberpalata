namespace Cyberpalata.ViewModel.Response.Booking
{
    public class BookingDetailsViewModel
    {
        public string RoomName { get; set; }
        public string Date { get; set; }
        public string Begining { get; set; }
        public int HoursCount { get; set; }
        public decimal Price { get; set; }
        public List<SeatViewModel> Seats { get; set; }
    }
}
