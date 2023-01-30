using Cyberpalata.Logic.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Booking
{
    public class BookingDto
    {
        [Required]
        public ApiUserDto User { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public DateTime Ending { get; set; }
        [Required]
        public PriceDto Tariff { get; set; }
        [Required]
        public RoomDto Room { get; set; }
        [Required]
        public List<SeatDto> Seats { get; set; }
        public List<GameDto> GamesToDownloadBefore { get; set; } = new();//have to check is the game in the cyberclub games list
        public bool IsExpired { get; set; } // trigger
    }
}
