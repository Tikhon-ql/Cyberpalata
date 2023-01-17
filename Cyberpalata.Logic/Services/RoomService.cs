﻿using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.Common.Enums;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    internal class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomDto entity)
        {
            await _repository.CreateAsync(_mapper.Map<Room>(entity));
        }

        public async Task<Maybe<RoomDto>> ReadAsync(Guid id)
        {
            return _mapper.Map<RoomDto>((await _repository.ReadAsync(id)).Value);
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var res = await SearchAsync(id);
            if (res.IsFailure)
                return Result.Fail(res.Error);

            _repository.Delete(_mapper.Map<Room>(res.Value));

            return Result.Ok();
        }

        public async Task<Result<RoomDto>> SearchAsync(Guid id)
        {
            var room = await _repository.ReadAsync(id);
            if (!room.HasValue)
                return (Result<RoomDto>)Result.Fail($"Room with id {id} doesn't exist");
            return Result.Ok(_mapper.Map<RoomDto>(room.Value));
        }

        public async Task<PagedList<Maybe<RoomDto>>> GetPagedListAsync(int pageNumber)
        {
            var list = await _repository.GetPageListAsync(pageNumber);
            return _mapper.Map<PagedList<Maybe<RoomDto>>>(list);
        }

        public async Task<PagedList<Maybe<RoomDto>>> GetPagedListAsync(int pageNumber, RoomType type)
        {
            var list = await _repository.GetPageListAsync(pageNumber, type);
            return _mapper.Map<PagedList<Maybe<RoomDto>>>(list);
        }
    }
}