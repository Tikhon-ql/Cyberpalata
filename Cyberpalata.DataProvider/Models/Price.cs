using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Models
{
    public class Price
    {
        public Price(int hours, decimal cost)
        {
            Hours = hours;
            Cost = cost;
        }

        public Guid Id { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
