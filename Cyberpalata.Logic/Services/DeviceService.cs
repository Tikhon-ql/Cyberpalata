using AutoMapper;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Services
{
    //public class DeviceService : IDeviceService
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IDeviceRepository _repository;

    //    public DeviceService(IMapper mapper, IDeviceRepository repository)
    //    {
    //        _mapper = mapper;
    //        _repository = repository;
    //    }

    //    public async Task CreateAsync(DeviceDto entity)
    //    {
    //        await _repository.CreateAsync(_mapper.Map<Device>(entity));
    //    }

    //    public async Task<DeviceDto> ReadAsync(Guid id)
    //    {
    //        //?
    //        return await Task.Run(async ()=>_mapper.Map<DeviceDto>( await _repository.ReadAsync(id))) ;
    //    }

    //    public async Task UpdateAsync(DeviceDto entity)
    //    {
    //        //_repository.Update(_mapper.Map<Device>(entity));
    //    }

    //    public async Task DeleteAsync(Guid id)
    //    {
    //        await _repository.DeleteAsync(id);
    //    }

    //    public async Task<PagedList<DeviceDto>> GetPagedListAsync(int pageNumber)
    //    {
    //        //?
    //        return await Task.Run(async()=> _mapper.Map<PagedList<DeviceDto>>(await _repository.GetPageListAsync(pageNumber))); ;
    //    }    
    //}
}
