using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Devices
{
    public class Device
    {
        [Key] [Required] public Guid Id { get; set; }
    }
}
