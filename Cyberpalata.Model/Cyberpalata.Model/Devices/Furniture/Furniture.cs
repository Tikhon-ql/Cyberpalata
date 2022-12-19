using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Devices.Furniture
{
    public class Furniture
    {
        public Furniture(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
