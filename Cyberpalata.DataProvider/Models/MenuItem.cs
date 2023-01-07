using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models
{
    public class MenuItem
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] [MaxLength(50)] public string Name { get; set; }
        [Required] public decimal Cost { get; set; }
        [Required] public MenuItemType Type { get; set; }
    }
}