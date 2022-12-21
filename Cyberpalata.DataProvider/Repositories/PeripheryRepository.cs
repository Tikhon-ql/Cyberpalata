using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
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
    public class PeripheryRepository : IPeripheryRepository
    {
        private readonly ApplicationDbContext _context;
        public PeripheryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Periphery entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Peripheries.Add(entity);
            _context.SaveChanges();
        }

        public Periphery Read(Guid id)
        {
            var Periphery = _context.Peripheries.AsNoTracking().FirstOrDefault(h => h.Id == id);
            if (Periphery == null)
                throw new ArgumentException(nameof(id), $"Not found periphery with id: {id}");
            return Periphery;
        }

        public void Update(Periphery entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var Periphery = _context.Peripheries.AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (Periphery == null)
                throw new ArgumentException(nameof(id), $"Not found Periphery with id: {id}");
            _context.Peripheries.Remove(Periphery);
            _context.SaveChanges();
        }

        public PagedList<Periphery> GetPageList(int pageNumber)
        {
            var list = _context.Peripheries.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Periphery>(list.ToList(), pageNumber, 10, _context.Peripheries.Count());
        }
    }
}
