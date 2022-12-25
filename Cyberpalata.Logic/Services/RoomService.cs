using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Rooms;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Rooms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    //public class RoomService : IRoomService
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IRoomRepository _repository;

    //    public RoomService(IMapper mapper, IRoomRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public void Create(RoomDto entity)
    //    {
    //        _repository.Create(_mapper.Map<Room>(entity));
    //    }

    //    public RoomDto Read(Guid id)
    //    {
    //        return _mapper.Map<RoomDto>(_repository.Read(id));
    //    }

    //    public void Update(RoomDto entity)
    //    {
    //        _repository.Update(_mapper.Map<Room>(entity));
    //    }

    //    public void Delete(Guid id)
    //    {
    //        _repository.Delete(id);
    //    }

    //    public PagedList<RoomDto> GetPagedList(int pageNumber)
    //    {
    //        return _mapper.Map<PagedList<RoomDto>>(_repository.GetPageList(pageNumber));
    //    }
    //}
}
