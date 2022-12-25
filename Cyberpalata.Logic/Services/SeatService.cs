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
    //public class SeatService : ISeatService
    //{

    //    private readonly IMapper _mapper;
    //    private readonly ISeatRepository _repository;

    //    public SeatService(IMapper mapper, ISeatRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public void Create(SeatDto entity)
    //    {
    //        _repository.Create(_mapper.Map<Seat>(entity));
    //    }

    //    public SeatDto Read(Guid id)
    //    {
    //        return _mapper.Map<SeatDto>(_repository.Read(id));
    //    }

    //    public void Update(SeatDto entity)
    //    {
    //        _repository.Update(_mapper.Map<Seat>(entity));
    //    }

    //    public void Delete(Guid id)
    //    {
    //        _repository.Delete(id);
    //    }

    //    public PagedList<SeatDto> GetPagedList(int pageNumber)
    //    {
    //        return _mapper.Map<PagedList<SeatDto>>(_repository.GetPageList(pageNumber));
    //    } 
    //}
}
