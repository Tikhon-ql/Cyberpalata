using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Services
{
    public class PriceService : IPriceService
    {

        private readonly IMapper _mapper;
        private readonly IPriceRepository _repository;
        private readonly IRoomRepository _roomRepository;

        public PriceService(IMapper mapper, IPriceRepository repository, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _roomRepository = roomRepository;
        }

        public async Task CreateAsync(PriceDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Price>(entity));
        }

        public async Task<Maybe<PriceDto>> ReadAsync(Guid id)
        {
            var price = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<PriceDto>>(price);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            _repository.Delete(_mapper.Map<Price>(res.Value));

            return Result.Success();
        }

        public async Task<Result<PriceDto>> SearchAsync(Guid id)
        {
            var price = await _repository.ReadAsync(id);

            if (!price.HasValue)
                return Result.Failure<PriceDto>($"Price with id {id} doesn't exist");

            return Result.Success(_mapper.Map<PriceDto>(price.Value));
        }

        public async Task<PagedList<PriceDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<PriceDto>>(list);
        }

        public async Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId)
        {
            var room = await _roomRepository.ReadAsync(roomId);
            if (room.HasNoValue)
                return Maybe.None;
            var prices = room.Value.Prices;
            return (_mapper.Map<List<PriceDto>>(prices)).AsMaybe();
        }
    }
}
