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
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApiUser User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
        [Required]
        public Guid PriceId { get; set; }
        [ForeignKey("PriceId")]
        public virtual Price Tariff { get; set; }
        public virtual List<Seat> Seats { get; set; }
        public virtual List<Game> GamesToDownloadBefore { get; set; }//have to check is the game in the cyberclub games list
    }
}
