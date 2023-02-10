using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Logic.Interfaces.Services;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Booking;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PagedList<GameDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<GameDto>>(list);
        }
    }
}
