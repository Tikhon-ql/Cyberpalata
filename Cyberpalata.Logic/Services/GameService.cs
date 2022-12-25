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
    public class GameService : IGameService
    {

        private readonly IMapper _mapper;
        private readonly IGameRepository _repository;

        public GameService(IMapper mapper, IGameRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task CreateAsync(GameDto entity)
        { 
            return _repository.CreateAsync(_mapper.Map<Game>(entity));
        }

        public Task<GameDto> ReadAsync(Guid id)
        {
            return Task.Run(async()=> _mapper.Map<GameDto>(await _repository.ReadAsync(id)));
        }

        public Task UpdateAsync(GameDto entity)
        {
            //_repository.Update(_mapper.Map<Game>(entity));
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<PagedList<GameDto>> GetPagedListAsync(int pageNumber)
        {
            return Task.Run(async ()=> _mapper.Map<PagedList<GameDto>>( await _repository.GetPageListAsync(pageNumber))) ;
        }
    }
}
