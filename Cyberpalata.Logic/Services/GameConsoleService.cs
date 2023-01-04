using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;
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
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public Task<PagedList<GameConsoleDto>> GetPagedListAsync(int pageNumber)
        {
            return Task.Run( async() => _mapper.Map<PagedList<GameConsoleDto>>(await _repository.GetPageListAsync(pageNumber)));
        }

        public async Task<List<GameConsoleDto>> GetByGameConsoleRoomId(Guid roomId)
        {
            return _mapper.Map<List<GameConsoleDto>>(await _repository.GetByGameConsoleRoomIdAsync(roomId));
        }
    }
}
