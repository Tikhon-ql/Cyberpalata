using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;

namespace Cyberpalata.Logic.Services
{
    internal class GameConsoleService : IGameConsoleService
    {
        private readonly IGameConsoleRepository _repository;
        private readonly IMapper _mapper;
        public GameConsoleService(IGameConsoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Maybe<GameConsoleDto> entity)
        {
            if (!entity.HasValue)
                return Result.Fail("Invalid game console creation request!");
            await _repository.CreateAsync(_mapper.Map<GameConsole>(entity));
            return Result.Ok();
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
                return Result.Fail(res.Error);

            _repository.Delete(_mapper.Map<GameConsole>(res.Value));
            return Result.Ok();
        }

        public async Task<Result<GameConsoleDto>> SearchAsync(Guid id)
        {
            var console = await _repository.ReadAsync(id);
            if (!console.HasValue)
                return Result.Fail<GameConsoleDto>($"Game console with id {id} doesn't exist");
            return Result.Ok(_mapper.Map<GameConsoleDto>(console.Value));
        }

        public async Task<PagedList<GameConsoleDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<GameConsoleDto>>(list);
        }

        public async Task<Maybe<List<GameConsoleDto>>> GetByGameConsoleRoomId(Guid roomId)
        {
            var list = await _repository.GetByGameConsoleRoomIdAsync(roomId);
            return _mapper.Map<Maybe<List<GameConsoleDto>>>(list);
        }
    }
}
