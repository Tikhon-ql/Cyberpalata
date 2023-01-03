using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models.Rooms;
using Cyberpalata.Logic.Interfaces.Room;
using Cyberpalata.Logic.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class GameConsoleRoomService : IGameConsoleRoomService
    {
        private readonly IGameConsoleRoomRepository _repository;
        private readonly IMapper _mapper;

        public GameConsoleRoomService(IGameConsoleRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

        public async Task CreateAsync(GameConsoleRoomDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<GameConsoleRoom>(entity));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        } 

        public async Task<GameConsoleRoomDto> ReadAsync(Guid id)
        {
            return _mapper.Map<GameConsoleRoomDto>(await _repository.ReadAsync(id));
        }

        public Task UpdateAsync(GameConsoleRoomDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<GameConsoleRoomDto>> GetPagedListAsync(int pageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Guid>> GetRoomIdsAsync()
        {
            return await _repository.GetRoomIdsAsync();
        }

        public async Task<List<string>> GetRoomNamesAsync()
        {
            return await _repository.GetRoomNamesAsync();
        }

        public async Task<List<Tuple<string, string>>> GetRoomNameWithIdAsync()
        {
            return await _repository.GetRoomNameWithIdAsync();
        }
    }
}
