using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
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

        public async Task CreateAsync(GameConsoleDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<GameConsole>(entity));
        }


        public async Task<Maybe<GameConsoleDto>> ReadAsync(Guid id)
        {
            var gameConsole = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<GameConsoleDto>>(gameConsole);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            _repository.Delete(_mapper.Map<GameConsole>(res.Value));
            return Result.Success();
        }

        public async Task<Result<GameConsoleDto>> SearchAsync(Guid id)
        {
            var console = await _repository.ReadAsync(id);
            if (!console.HasValue)
                return Result.Failure<GameConsoleDto>($"Game console with id {id} doesn't exist");
            return Result.Success(_mapper.Map<GameConsoleDto>(console.Value));
        }

        public async Task<PagedList<GameConsoleDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<GameConsoleDto>>(list);
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
