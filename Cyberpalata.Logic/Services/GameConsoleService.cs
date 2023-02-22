using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Services
{
    internal class GameConsoleService : IGameConsoleService
    {
        private readonly IGameConsoleRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public GameConsoleService(IGameConsoleRepository repository,IRoomRepository roomRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<Maybe<List<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId)
        {
            var room = await _roomRepository.ReadAsync(roomId);
            if (room.HasNoValue)
                return Maybe.None;
            var list = room.Value.Consoles;
            return _mapper.Map<Maybe<List<GameConsoleDto>>>(list);
        }
    }
}
