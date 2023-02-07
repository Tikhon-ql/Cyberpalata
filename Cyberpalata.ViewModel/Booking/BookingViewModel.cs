using Cyberpalata.ViewModel.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Booking
{
    public class BookingViewModel
    {
        public string RoomName { get; set; }
        public string Date { get; set; }
        public string Begining { get; set; }
        public int HoursCount { get; set; }
        public decimal Price { get; set; }
        public List<SeatBookingViewModel> Seats { get; set; }
    }
}
