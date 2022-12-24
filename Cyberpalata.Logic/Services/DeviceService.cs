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
    public class DeviceService : IDeviceService
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _repository;

        public DeviceService(IMapper mapper, IDeviceRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(DeviceDto entity)
        {
            _repository.Create(_mapper.Map<Device>(entity));
        }

        public DeviceDto Read(Guid id)
        {
            return _mapper.Map<DeviceDto>(_repository.Read(id));
        }

        public void Update(DeviceDto entity)
        {
            _repository.Update(_mapper.Map<Device>(entity));
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public PagedList<DeviceDto> GetPagedList(int pageNumber)
        {
            return _mapper.Map<PagedList<DeviceDto>>(_repository.GetPageList(pageNumber));
        }    
    }
}
