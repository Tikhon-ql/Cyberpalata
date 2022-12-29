using Cyberpalata.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Peripheral
{
    public class PeripheryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public PeripheryType? Type { get; set; }
    }
}
