using Cyberpalata.DataProvider.Models;
using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.DataProvider.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        //[Required]//constraint gaming room X game console room only
        ///public Room Room { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public DateTime Ending { get; set; }
        [Required]
        public Price Tariff { get; set; }
        [Required]
        public virtual List<Seat> Seats { get; set; }
        public virtual List<Game> GamesToDownloadBefore { get; set; }//have to check is the game in the cyberclub games list
        public bool IsExpired { get; set; } // trigger
    }
}
