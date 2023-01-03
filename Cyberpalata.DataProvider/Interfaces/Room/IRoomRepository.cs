using Cyberpalata.DataProvider.Models;
using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces.Room
{
    public interface IRoomRepository
    {
        Task<List<Guid>> GetRoomIdsAsync();
        Task<List<string>> GetRoomNamesAsync();

        Task<List<Tuple<string,string>>> GetRoomNameWithIdAsync();
 
        List<Price> GetPrices(Guid id);
        List<Seat> GetSeats(Guid id);
    }
}
