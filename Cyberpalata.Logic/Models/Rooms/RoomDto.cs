using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models.Rooms
{
    public class RoomDto
    {
        public RoomDto(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }


        public virtual List<PriceDto> Prices { get; set; } = new();
        public virtual List<SeatDto> AllSeats { get; set; } = new();
        public virtual List<SeatDto> FreeSeats { get; set; } = new();
    }
}
