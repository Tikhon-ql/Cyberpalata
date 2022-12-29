using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Services
{
    public class PcService : IPcService
    {
        private readonly IPcRepository _repository;
        private readonly IMapper _mapper;

        public PcService(IPcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(PcDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Pc>(entity));
        }

        public async Task<PcDto> ReadAsync(Guid id)
        {
            return _mapper.Map<PcDto>(await _repository.ReadAsync(id));
        }

        public Task UpdateAsync(PcDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedList<PcDto>> GetPagedListAsync(int pageNumber)
        {
            return _mapper.Map<PagedList<PcDto>>(await _repository.GetPageListAsync(pageNumber));
        }
    }
}
