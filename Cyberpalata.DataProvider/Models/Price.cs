using Cyberpalata.DataProvider.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Price
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public int Hours { get; set; }
        [Required] public decimal Cost { get; set; }
        [Required] public Room? Room { get; set; }
    }
}
