using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Filters
{
    public class RoomFilterViewModel
    {
        public string SearchName { get; set; }
        public int FreeSeatsCount { get; set; }
        public int FreeSeatsInRowCount { get; set; }
        public int HoursCount { get; set; }
        public string Begining { get; set; }
        public string Date { get; set; }
        public int Page { get; set; }
    }
}
