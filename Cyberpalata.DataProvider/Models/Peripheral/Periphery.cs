using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Periphery
    {
        [Key] [Required] public Guid Id { get; set; }
        [MaxLength(50)] [Required] public string? Name { get; set; }
        [Required] public PeripheryType? Type { get; set; }
    }
}
