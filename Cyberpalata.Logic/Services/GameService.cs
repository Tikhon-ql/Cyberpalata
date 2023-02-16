using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Services
{
    internal class GameService : IGameService
    {
        private readonly IGameRepository _repository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedList<GameDto>> GetPagedListAsync(BaseFilterBL filter)
        {
            var list = await _repository.GetPageListAsync(_mapper.Map<BaseFilter<Game>>(filter));
            return _mapper.Map<PagedList<GameDto>>(list);
        }
    }
}
