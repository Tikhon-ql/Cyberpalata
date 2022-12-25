using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Peripheral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    //public class PeripheryService : IPeripheryService
    //{

    //    private readonly IMapper _mapper;
    //    private readonly IPeripheryRepository _repository;

    //    public PeripheryService(IMapper mapper, IPeripheryRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public void Create(PeripheryDto entity)
    //    {
    //        _repository.Create(_mapper.Map<Periphery>(entity));
    //    }

    //    public PeripheryDto Read(Guid id)
    //    {
    //        return _mapper.Map<PeripheryDto>(_repository.Read(id));
    //    }

    //    public void Update(PeripheryDto entity)
    //    {
    //        _repository.Update(_mapper.Map<Periphery>(entity));
    //    }

    //    public void Delete(Guid id)
    //    {
    //        _repository.Delete(id);
    //    }

    //    public PagedList<PeripheryDto> GetPagedList(int pageNumber)
    //    {
    //        return _mapper.Map<PagedList<PeripheryDto>>(_repository.GetPageList(pageNumber));
    //    }
    //}
}
