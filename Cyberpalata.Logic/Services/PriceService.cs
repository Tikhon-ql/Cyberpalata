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
    public class PriceService : IPriceService
    {

        private readonly IMapper _mapper;
        private readonly IPriceRepository _repository;

        public PriceService(IMapper mapper, IPriceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task CreateAsync(PriceDto entity)
        {
            _repository.CreateAsync(_mapper.Map<Price>(entity));
        }

        public async Task<PriceDto> ReadAsync(Guid id)
        {
            return _mapper.Map<PriceDto>(await _repository.ReadAsync(id));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<PriceDto>> GetPagedListAsync(int pageNumber)
        {
            return _mapper.Map<PagedList<PriceDto>>(await _repository.GetPageListAsync(pageNumber));
        }

        public async Task<List<PriceDto>> GetByRoomIdAsync(Guid roomId)
        {
            return _mapper.Map<List<PriceDto>>(await _repository.GetByRoomIdAsync(roomId));
        }
    }
}
