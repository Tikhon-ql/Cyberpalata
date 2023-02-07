using Cyberpalata.Logic.Models.Identity.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Booking
{
    public class BookingCreateRequest
    {
        public Guid RoomId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Begining { get; set; }
        public int HoursCount { get; set; }
        public decimal Price { get; set; }
        public List<int> Seats { get; set; } = new();
    }
}
