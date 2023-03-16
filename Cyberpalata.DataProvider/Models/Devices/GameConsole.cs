using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class GameConsole : BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string ConsoleName { get; set; }
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]
        
        public virtual Room ConsoleRoom { get; set; }
    }
}