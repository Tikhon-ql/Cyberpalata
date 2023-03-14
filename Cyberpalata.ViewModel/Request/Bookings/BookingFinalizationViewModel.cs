using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.ViewModel.Request.Bookings
{
    public class BookingFinalizationViewModel
    {
        public Guid BookingId { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardCvv { get; set; }
    }
}
