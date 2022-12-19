using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Devices
{
    public abstract class Device
    {
        protected Device(string name)
        {

            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
