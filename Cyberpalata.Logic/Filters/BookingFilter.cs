using Cyberpalata.Logic.Interfaces.Filters;
using Cyberpalata.Logic.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Filters
{
    internal class BookingFilter : IBookingFilter
    {
        public bool IsValid(BookingDto obj)
        {
            //if(obj.Date <= DateTime.Now || obj.Begining >= obj.Ending)
            //    return false;
            return true;
        }
    }
}
