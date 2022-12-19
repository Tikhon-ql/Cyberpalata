using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Model.Devices.Furniture;
using Cyberpalata.Model.Hardwares;

namespace Cyberpalata.Model.Modules
{
    public class ConsoleModule : Module
    {
        public ConsoleModule(string name, Furniture furniture) : base(name, furniture)
        {
        }
        public Hardware Hardware { get; set; } = new();
    }
}
