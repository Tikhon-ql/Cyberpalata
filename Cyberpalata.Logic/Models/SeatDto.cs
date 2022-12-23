using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models
{
    public class SeatDto
    {
        public SeatDto(int number)
        {
            Number = number;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
