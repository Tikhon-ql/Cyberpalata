using Cyberpalata.DataProvider.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public abstract class Periphery
    {
        protected Periphery(string name, PeripheryType type)
        {

            Name = name;
            Type = type;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PeripheryType Type { get; set; }
    }
}
