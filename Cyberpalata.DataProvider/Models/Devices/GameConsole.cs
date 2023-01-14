
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class GameConsole
    {
        [Key][Required] public Guid Id { get; set; }
        [MaxLength(50)] [Required] public string ConsoleName { get; set; }
        [Required] public virtual Room ConsoleRoom { get; set; }
    }
}