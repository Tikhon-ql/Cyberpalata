using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Interfaces;
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

        public async Task<Result> CreateAsync(Maybe<PeripheryDto> entity)
        {
            if (!entity.HasValue)
                return Result.Failure("Invalid entity creation request!");
            await _repository.CreateAsync(_mapper.Map<Periphery>(entity));
            return Result.Success();
        }

        public async Task<Maybe<PeripheryDto>> ReadAsync(Guid id)
        {
            var periphery = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<PeripheryDto>>(periphery);
        }


        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            _repository.Delete(_mapper.Map<Periphery>(res.Value));

            return Result.Success();
        }

        public async Task<Result<PeripheryDto>> SearchAsync(Guid id)
        {
            var periphery = await _repository.ReadAsync(id);

            if (!periphery.HasValue)
                return Result.Failure<PeripheryDto>($"Periphery with id {id} doesn't exist");

            return Result.Success(_mapper.Map<PeripheryDto>(periphery.Value));
        }

        public async Task<PagedList<PeripheryDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<PeripheryDto>>(list);
        }

        public async Task<Maybe<List<PeripheryDto>>> GetByGamingRoomId(Guid roomId)
        {
            var list = await _repository.GetByGamingRoomId(roomId);
            return _mapper.Map<Maybe<List<PeripheryDto>>>(list);
        }
    }
}
