using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Enums;

namespace Cyberpalata.ViewModel.Rooms.GamingRoom
{
    public class Periphery
    {
        public Periphery(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
        public string? Name { get; set; }
        public string? TypeName { get; set; }
    }
}
