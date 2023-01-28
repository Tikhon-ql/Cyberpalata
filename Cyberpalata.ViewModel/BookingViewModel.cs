using Cyberpalata.ViewModel.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel
{
    public class BookingViewModel
    {
        public string RoomName { get; set; }
        public List<Seat> Seats { get; set; } = new();
        public List<Price> Tariffs { get; set; } = new();
    }
}
