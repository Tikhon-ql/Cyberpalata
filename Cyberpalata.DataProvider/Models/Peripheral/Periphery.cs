using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.DataProvider.Models.Peripheral
{
    public class Periphery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PeripheryType Type { get; set; }
    }
}
