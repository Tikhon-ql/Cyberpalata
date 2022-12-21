using Cyberpalata.DataProvider.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models.Support
{
    public class MenuPosition
    {
        public MenuPosition(string name, decimal cost, MenuPositionType type = MenuPositionType.Food)
        {
            Name = name;
            Cost = cost;
            Type = type;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public MenuPositionType Type { get; set; }
    }
}
