using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Booking
{
    public class BookingCreateRequest
    {
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
        public string Tariff { get; set; }
        public List<int> Seats { get; set; } = new();
    }
}
