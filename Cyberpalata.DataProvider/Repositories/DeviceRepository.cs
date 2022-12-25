using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public DeviceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Device entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.Devices.AddAsync(entity);
        }

        public async Task<Device> ReadAsync(Guid id)
        {
            var device = await _context.Devices.SingleAsync(d => d.Id == id);
            return device;
        }

        public async Task DeleteAsync(Guid id)
        {
            var device = await _context.Devices.SingleAsync(d => d.Id == id);
            _context.Devices.Remove(device);//?
        }

        private PagedList<Device> GetPageList(int pageNumber)
        {
            var list = _context.Devices.Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<Device>(list.ToList(), pageNumber, 10, _context.Devices.Count());
        }

        public async Task<PagedList<Device>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
