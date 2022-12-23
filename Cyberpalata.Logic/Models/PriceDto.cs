using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Models
{
    public class PriceDto
    {
        public PriceDto(int hours, decimal cost)
        {
            Hours = hours;
            Cost = cost;
        }

        public Guid Id { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
