using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Room
{
    public interface IRoomService
    {
        Task<List<Guid>> GetRoomIdsAsync();
        Task<List<string>> GetRoomNamesAsync();

        Task<List<Tuple<string, string>>> GetRoomNameWithIdAsync();
    }
}
