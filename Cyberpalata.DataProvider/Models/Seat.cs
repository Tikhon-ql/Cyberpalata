using System.ComponentModel.DataAnnotations;
using Cyberpalata.DataProvider.Models.Rooms;

namespace Cyberpalata.DataProvider.Models
{
    public class Seat
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public int Number { get; set; }
        [Required] public Room Room { get; set; }
    }
}
