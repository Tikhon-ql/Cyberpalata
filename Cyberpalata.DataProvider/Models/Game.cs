using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Game
    {
        [Key] [Required] public Guid Id { get; set; }
        [MaxLength(50)] [Required] public string GameName { get; set; }
    }
}
