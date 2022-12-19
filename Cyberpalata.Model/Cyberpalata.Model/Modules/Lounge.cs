using Cyberpalata.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Model.Devices.Furniture;

namespace Cyberpalata.Model.Modules
{
    public class Lounge : Module
    {
        public Lounge(string name, Furniture furniture) : base(name, furniture)// or need to use sofa?
        {
        }

        public virtual List<MenuPosition> Menu { get; set; } = new();

    }
}
