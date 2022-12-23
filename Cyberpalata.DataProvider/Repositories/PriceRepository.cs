using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _context;
        public PriceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Price entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Prices.Add(entity);
            _context.SaveChanges();
        }

        public Price Read(Guid id)
        {
            var price = _context.Prices.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (price == null)
                throw new ArgumentException(nameof(id), $"Not found price with id: {id}");
            return price;
        }

        public void Update(Price entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var price = _context.Prices.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (price == null)
                throw new ArgumentException(nameof(id), $"Not found price with id: {id}");
            _context.Prices.Remove(price);
            _context.SaveChanges();
        }

        public PagedList<Price> GetPageList(int pageNumber)
        {
            var list = _context.Prices.Skip((pageNumber - 1) * 10).Take(10);
            return new PagedList<Price>(list.ToList(), pageNumber, 10, _context.Prices.Count());
        }
    }
}
