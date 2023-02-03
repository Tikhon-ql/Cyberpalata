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
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
        public PriceViewModel Tariff { get; set; }
        public List<SeatBookingViewModel> Seats { get; set; }
    }
}
