using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models.Peripheral;

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

        public async Task<PagedList<PeripheryDto>> GetPageList(PeripheriesFilterBl filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<PeripheriesFilter>(filter));
            return _mapper.Map<PagedList<PeripheryDto>>(list);
        }
    }
}
