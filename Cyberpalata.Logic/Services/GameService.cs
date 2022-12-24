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

        public void Create(GameDto entity)
        {
            _repository.Create(_mapper.Map<Game>(entity));
        }

        public GameDto Read(Guid id)
        {
            return _mapper.Map<GameDto>(_repository.Read(id));
        }

        public void Update(GameDto entity)
        {
            _repository.Update(_mapper.Map<Game>(entity));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public PagedList<GameDto> GetPagedList(int pageNumber)
        {
            return _mapper.Map<PagedList<GameDto>>(_repository.GetPageList(pageNumber));
        }
    }
}
