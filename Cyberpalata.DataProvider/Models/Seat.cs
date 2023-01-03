using Cyberpalata.DataProvider.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Seat
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public int Number { get; set; }
        [Required] public Room? Room { get; set; }
    }
}
