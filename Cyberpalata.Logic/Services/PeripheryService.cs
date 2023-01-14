using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    public class PeripheryService : IPeripheryService
    {

        private readonly IMapper _mapper;
        private readonly IPeripheryRepository _repository;

        public PeripheryService(IMapper mapper, IPeripheryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(PeripheryDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Periphery>(entity));
        }

        public async Task<PeripheryDto> ReadAsync(Guid id)
        {
            return _mapper.Map<PeripheryDto>(await _repository.ReadAsync(id));
        }


        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<PeripheryDto>> GetPagedListAsync(int pageNumber)
        {
            return _mapper.Map<PagedList<PeripheryDto>>(await _repository.GetPageListAsync(pageNumber));
        }

        public async Task<List<PeripheryDto>> GetByGamingRoomId(Guid roomId)
        {
            return _mapper.Map<List<PeripheryDto>>(await _repository.GetByGamingRoomId(roomId));
        }
    }
}
