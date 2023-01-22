using AutoMapper;
using CSharpFunctionalExtensions;
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
    internal class SeatService : ISeatService
    {
        private readonly ISeatRepository _repository;
        private readonly IMapper _mapper;

        public SeatService(ISeatRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SeatDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Seat>(entity));
        }

        public async Task CreateRangeAsync(List<SeatDto> seats)
        {
            await _repository.CreateRangeAsync(_mapper.Map<List<Seat>>(seats));
        }

        public async Task<Maybe<SeatDto>> ReadAsync(Guid id)
        {
            var seat = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<SeatDto>>(seat);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var result = await SearchAsync(id);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            _repository.Delete(_mapper.Map<Seat>(result.Value));

            return Result.Success();
        }
        public async Task<Result<SeatDto>> SearchAsync(Guid id)
        {
            var seat = await _repository.ReadAsync(id);
            if (!seat.HasValue)
                return Result.Failure<SeatDto>($"Seat with id {id} doesn't exist");
            return Result.Success(_mapper.Map<SeatDto>(seat.Value));
        }

        public Task<PagedList<SeatDto>> GetPagedListAsync(int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
