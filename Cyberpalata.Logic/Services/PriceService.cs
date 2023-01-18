﻿using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using Cyberpalata.Logic.Models.Peripheral;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    public class PriceService : IPriceService
    {

        private readonly IMapper _mapper;
        private readonly IPriceRepository _repository;

        public PriceService(IMapper mapper, IPriceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
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
                return Result.Fail(res.Error);

            _repository.Delete(_mapper.Map<Price>(res.Value));

            return Result.Ok();
        }

        public async Task<Result<PriceDto>> SearchAsync(Guid id)
        {
            var price = await _repository.ReadAsync(id);

            if (!price.HasValue)
                return Result.Fail<PriceDto>($"Price with id {id} doesn't exist");

            return Result.Ok(_mapper.Map<PriceDto>(price.Value));
        }

        public async Task<PagedList<PriceDto>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<PriceDto>>(list);
        }

        public async Task<Maybe<List<PriceDto>>> GetByRoomIdAsync(Guid roomId)
        {
            var list = await _repository.GetByRoomIdAsync(roomId);
            return _mapper.Map<Maybe<List<PriceDto>>>(list);
        }
    }
}
