using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.ViewModel.GamingRoom;

namespace Cyberpalata.Logic.Services
{
    public class GamingRoomViewModelService : IGamingRoomViewModelService
    {
        private readonly IRoomRepository _roomRepository;

        public GamingRoomViewModelService(IRoomRepository repository)
        {
            _roomRepository = repository;
        }
        public void Create(GamingRoomViewModel entity)
        {
            _roomRepository.Create(null);
        }

        public GamingRoomViewModel Read(Guid id)
        {
            var res = _roomRepository.Read(id);
            return null;
        }

        public void Update(GamingRoomViewModel entity)
        {
            _roomRepository.Update(null);
        }

        public void Delete(Guid id)
        {
            _roomRepository.Delete(id);
        }
    }
}
