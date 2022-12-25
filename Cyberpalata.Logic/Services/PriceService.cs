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
    //public class PriceService : IPriceService
    //{

    //    private readonly IMapper _mapper;
    //    private readonly IPriceRepository _repository;

    //    public PriceService(IMapper mapper, IPriceRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public void Create(PriceDto entity)
    //    {
    //        _repository.Create(_mapper.Map<Price>(entity));
    //    }

    //    public PriceDto Read(Guid id)
    //    {
    //        return _mapper.Map<PriceDto>(_repository.Read(id));
    //    }

    //    public void Update(PriceDto entity)
    //    {
    //        _repository.Update(_mapper.Map<Price>(entity));
    //    }

    //    public void Delete(Guid id)
    //    {
    //        _repository.Delete(id);
    //    }

    //    public PagedList<PriceDto> GetPagedList(int pageNumber)
    //    {
    //        return _mapper.Map<PagedList<PriceDto>>(_repository.GetPageList(pageNumber));
    //    }
    //}
}
