using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Room>(entity));
        }

        public async Task<RoomDto> ReadAsync(Guid id)
        {
            return _mapper.Map<RoomDto>(await _repository.ReadAsync(id));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<RoomDto>> GetPagedListAsync(int pageNumber)
        {
            return _mapper.Map<PagedList<RoomDto>>(await _repository.GetPageListAsync(pageNumber));
        }
    }
}
