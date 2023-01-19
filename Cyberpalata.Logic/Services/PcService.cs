﻿using AutoMapper;
using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Services
{
    public class PcService : IPcService
    {
        private readonly IPcRepository _repository;
        private readonly IMapper _mapper;

        public PcService(IPcRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result> CreateAsync(Maybe<PcDto> entity)
        {
            if (!entity.HasValue)
                return Result.Failure("Invalid pc creation request!");
            await _repository.CreateAsync(_mapper.Map<Pc>(entity));
            return Result.Success();
        }

        public async Task<Maybe<PcDto>> ReadAsync(Guid id)
        {
            var pc = await _repository.ReadAsync(id);
            return _mapper.Map<Maybe<PcDto>>(pc);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);

            if (res.IsFailure)
                return Result.Failure(res.Error);

            _repository.Delete(_mapper.Map<Pc>(res.Value));

            return Result.Success();
        }

        public async Task<Result<PcDto>> SearchAsync(Guid id)
        {
            var pc = await _repository.ReadAsync(id);

            if (!pc.HasValue)
                return Result.Failure<PcDto>($"Pc with id {id} doesn't exist");

            return Result.Success(_mapper.Map<PcDto>(pc.Value));
        }

        public async Task<PagedList<PcDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<PcDto>>(list);
        }

        public async Task<Maybe<PcDto>> GetByGamingRoomId(Guid roomId)
        {
            var pc = await _repository.GetByGamingRoomId(roomId);
            return _mapper.Map<Maybe<PcDto>>(pc);
        }   
    }
}
