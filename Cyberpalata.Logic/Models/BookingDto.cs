using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public DateTime Ending { get; set; }
        [Required]
        public PriceDto Tariff { get; set; }
        [Required]
        public virtual List<SeatDto> Seats { get; set; }
        public virtual List<GameDto> GamesToDownloadBefore { get; set; }//have to check is the game in the cyberclub games list
    }
}
