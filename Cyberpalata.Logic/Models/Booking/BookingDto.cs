using Cyberpalata.Logic.Models.Identity.User;
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
        public Guid Id { get; set; }
        [Required]
        public ApiUserDto User { get; set; } = new();
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public RoomDto Room { get; set; } = new();
        [Required]
        public DateTime Ending { get; set; }
        [Required]
        public PriceDto Tariff { get; set; }
        [Required]
        public List<SeatDto> Seats { get; set; } = new();
        public List<GameDto> GamesToDownloadBefore { get; set; } = new();//have to check is the game in the cyberclub games list
        public bool IsExpired { get; set; } // trigger
    }
}
