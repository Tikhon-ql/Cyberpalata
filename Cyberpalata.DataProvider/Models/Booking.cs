using Cyberpalata.DataProvider.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models
{
    public class Booking : BaseEntity
    {
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Begining { get; set; }
        [Required]
        public int HoursCount { get; set; }
        [Required]
        public decimal Price { get;set; }
        public bool? IsPaid { get; set; }
        public virtual List<Seat>? Seats { get; set; }
        public virtual List<Game>? GamesToDownloadBefore { get; set; }
    }
}
