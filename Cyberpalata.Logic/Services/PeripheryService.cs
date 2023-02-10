using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Peripheral;

namespace Cyberpalata.Logic.Services
{
    public class PeripheryService : IPeripheryService
    {

        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IPeripheryRepository _repository;

        public PeripheryService(IMapper mapper, IPeripheryRepository repository, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _roomRepository = roomRepository;
        }

        public async Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId)
        {
            var room = await _roomRepository.ReadAsync(roomId);
            if (room.HasNoValue)
                return Maybe.None;
            var periphries = room.Value.Peripheries;
            return _mapper.Map<List<PeripheryDto>>(periphries).AsMaybe();
        }
    }
}
