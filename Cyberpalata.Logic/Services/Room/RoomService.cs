using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.Logic.Interfaces.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services.Room
{
    internal class RoomService : IRoomService
    {
        protected readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }
        public virtual async Task<List<Tuple<string, string>>> GetRoomNameWithIdAsync()
        {
            return await _repository.GetRoomNameWithIdAsync();
        }

        public Task<List<Guid>> GetRoomIdsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRoomNamesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
