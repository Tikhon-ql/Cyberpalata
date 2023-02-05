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
        public DateTime Date { get; set; }
        public TimeSpan Begining { get; set; }
        public TimeSpan Ending { get; set; }
    }
}
