using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;
using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task CreateAsync(PeripheryDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Periphery>(entity));
        }

        public async Task<Maybe<PeripheryDto>> ReadAsync(Guid id)
        {
            return _mapper.Map<PeripheryDto>((await _repository.ReadAsync(id)).Value);
        }


        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);
            if (res.IsFailure)
                return Result.Fail(res.Error);

            _repository.Delete(_mapper.Map<Periphery>(res.Value));

            return Result.Ok();
        }

        public async Task<Result<PeripheryDto>> SearchAsync(Guid id)
        {
            var periphery = await _repository.ReadAsync(id);
            if (!periphery.HasValue)
                return (Result<PeripheryDto>)Result.Fail($"Periphery with id {id} doesn't exist");
            return Result.Ok(_mapper.Map<PeripheryDto>(periphery.Value));
        }

        public async Task<PagedList<Maybe<PeripheryDto>>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<Maybe<PeripheryDto>>>(list);
        }

        public async Task<List<Maybe<PeripheryDto>>> GetByGamingRoomId(Guid roomId)
        {
            var list = await _repository.GetByGamingRoomId(roomId);
            return _mapper.Map<List<Maybe<PeripheryDto>>>(list);
        }
    }
}
