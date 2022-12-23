using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Rooms
{
    public class LoungeDto : RoomDto
    {
        public LoungeDto() : base("Lounge") { }
        public virtual List<MenuItemDto> Menu { get; set; } = new();
    }
}
