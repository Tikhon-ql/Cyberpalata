using Cyberpalata.Model.Devices;
using Cyberpalata.Model.Devices.Furniture;
using Cyberpalata.Model.Enums;
using Cyberpalata.Model.Hardwares;
using Cyberpalata.Model.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Modules
{
    public class GamingModule : Module
    {
        public GamingModule(string name, Furniture furniture) : base(name, furniture) // or need to use Chair?
        {

        }
        public Hardware Hardware { get; set; } = new();//? or need to use PCHarware

        public Screen Screen { get; set; }
        public Mouse Mouse { get; set; }
        public Keypad Keypad { get; set; }
        public Headphones Headphones { get; set; }

        public virtual List<Game> DownloadedGames { get; set; } = new();

        public GamingModuleType Type { get; set; } = GamingModuleType.Common;

    }
}
