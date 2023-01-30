using Cyberpalata.Logic.Models.Identity;
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
        [JsonProperty("user")]
        public ApiUserDto User { get; set; } = new ApiUserDto();
        public Guid RoomId { get; set; }
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
        public PriceDto Tariff { get; set; } = new PriceDto();
        public List<int> Seats { get; set; } = new();
    }
}
