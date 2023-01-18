using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Functional.Maybe;

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

        public async Task<Result> CreateAsync(Maybe<GameDto> entity)
        {
            if (!entity.HasValue)
                return Result.Fail("Invalid game creation request!");
            await _repository.CreateAsync(_mapper.Map<Game>(entity));
            return Result.Ok();
        }

        public async Task<Maybe<GameDto>> ReadAsync(Guid id)
        {
            var game = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<GameDto>>(game);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Fail(res.Error);

            _repository.Delete(_mapper.Map<Game>(res.Value));

            return Result.Ok();
        }
        //??? Do i need it
        public async Task<Result<GameDto>> SearchAsync(Guid id)
        {
            var game = await _repository.ReadAsync(id);

            if (!game.HasValue)
                return Result.Fail<GameDto>($"Game with id {id} doesn't exist");

            return Result.Ok(_mapper.Map<GameDto>(game.Value));
        }

        public async Task<PagedList<GameDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<GameDto>>(list);
        }    
    }
}
