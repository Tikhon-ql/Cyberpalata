using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.DataProvider.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public DeviceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Device entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Devices.Add(entity);
            _context.SaveChanges();
        }

        public Device Read(Guid id)
        {
            var device = _context.Devices.AsNoTracking().FirstOrDefault(d => d.Id == id);
            if (device == null)
                throw new ArgumentException(nameof(id), $"Not found device with id: {id}");
            return device;
        }

        public void Update(Device entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var device = _context.Devices.AsNoTracking().FirstOrDefault(d => d.Id == id);
            if (device == null)
                throw new ArgumentException(nameof(id), $"Not found device with id: {id}");
            _context.Devices.Remove(device);
            _context.SaveChanges();
        }

        public PagedList<Device> GetPageList(int pageNumber)
        {
            var list = _context.Devices.Skip((pageNumber - 1) * 10).Take(10).ToList();
            return new PagedList<Device>(list.ToList(), pageNumber, 10, _context.Devices.Count());
        }
    }
}
