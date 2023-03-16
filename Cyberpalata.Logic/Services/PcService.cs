using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
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

        public async Task<PagedList<PcDto>> GetPagedList(PcFilterBl filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<PcFilter>(filter));
            return _mapper.Map<PagedList<PcDto>>(list); 
        }
    }
}
