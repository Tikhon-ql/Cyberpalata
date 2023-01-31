using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        [Required]//constraint gaming room X game console room only
        public virtual Room Room { get; set; }
        [Required]
        public virtual ApiUser User { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        [Required]
        public DateTime Ending { get; set; }
        [Required]
        public virtual Price Tariff { get; set; }
        public virtual List<Seat>? Seats { get; set; }
        public virtual List<Game> GamesToDownloadBefore { get; set; }//have to check is the game in the cyberclub games list
    }
}
