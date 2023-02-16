namespace Cyberpalata.ViewModel.Response.Booking
{
    public class BookingCollectionViewModel
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string Date { get; set; }
        public string Begining { get; set; }
        public int HoursCount { get; set; }
        public decimal Price { get; set; }
    }
}
