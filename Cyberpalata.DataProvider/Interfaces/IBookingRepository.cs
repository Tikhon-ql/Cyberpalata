using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<bool> CheckIsSeatFreeAsync(Seat seat);
    }
}
