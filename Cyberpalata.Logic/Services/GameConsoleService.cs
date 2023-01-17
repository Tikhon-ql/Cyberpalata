using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateAsync(GameConsoleDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<GameConsole>(entity));
        }


        public async Task<GameConsoleDto> ReadAsync(Guid id)
        { 
            return _mapper.Map<GameConsoleDto>(await _repository.ReadAsync(id));
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
                return (Result<GameConsoleDto>)Result.Fail($"Game console with id {id} doesn't exist");
            return Result.Ok(_mapper.Map<GameConsoleDto>(console.Value));
        }

        public async Task<PagedList<GameConsoleDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<GameConsoleDto>>(list);
        }

        public async Task<List<GameConsoleDto>> GetByGameConsoleRoomId(Guid roomId)
        {
            var list = await _repository.GetByGameConsoleRoomIdAsync(roomId);
            return _mapper.Map<List<GameConsoleDto>>(list);
        }
    }
}
