using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Booking
{
    public class BookingSmallViewModel
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
    }
}
