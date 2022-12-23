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
        public PeripheryDto(string name, PeripheryType type)
        {
            Name = name;
            Type = type;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PeripheryType Type { get; set; }
    }
}
