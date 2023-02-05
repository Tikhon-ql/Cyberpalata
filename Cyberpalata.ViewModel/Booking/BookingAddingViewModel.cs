using Cyberpalata.ViewModel.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Booking
{
    public class BookingAddingViewModel
    {
        public string RoomName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Begining { get; set; }
        public TimeSpan Ending { get; set; }
        public List<Rooms.SeatViewModel> Seats { get; set; } = new();
        public List<PriceViewModel> Tariffs { get; set; } = new();
    }
}
