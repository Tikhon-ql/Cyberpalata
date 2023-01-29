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
        public DateTime Begining { get; set; }
        public DateTime Ending { get; set; }
        [JsonProperty("tariff")]
        public PriceDto Tariff { get; set; } = new PriceDto();
        public List<int> Seats { get; set; } = new();
    }
}
