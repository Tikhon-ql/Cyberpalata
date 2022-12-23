using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Seat
    {
        public Seat(int number)
        {
            Number = number;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
