using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Support;
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
    public class MenuPositionRepository : IMenuPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuPositionRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(MenuPosition entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.MenuPositions.Add(entity);
            _context.SaveChanges();
        }

        public MenuPosition Read(Guid id)
        {
            var position = _context.MenuPositions.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (position == null)
                throw new ArgumentException(nameof(id), $"Not found menu position with id: {id}");
            return position;
        }

        public void Update(MenuPosition entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var position = _context.MenuPositions.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (position == null)
                throw new ArgumentException(nameof(id), $"Not found menu position with id: {id}");
            _context.MenuPositions.Remove(position);
            _context.SaveChanges();
        }

        public PagedList<MenuPosition> GetPageList(int pageNumber)
        {
            var list = _context.MenuPositions.Skip((pageNumber - 1) * 20).Take(20);
            return new PagedList<MenuPosition>(list.ToList(), pageNumber, 20, _context.MenuPositions.Count());
        }
    }
}
