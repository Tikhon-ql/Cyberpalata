using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Seats
{
    public class SeatsGettingRequest
    {
        public Guid RoomId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Begining { get; set; }
        public TimeSpan Ending { get; set; }
    }
}
