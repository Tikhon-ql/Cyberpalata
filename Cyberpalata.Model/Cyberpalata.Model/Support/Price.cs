using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Support
{
    public class Price
    {
        public Guid Id { get; set; }
        public int Hours { get; set; }
        public decimal Cost { get; set; }
    }
}
