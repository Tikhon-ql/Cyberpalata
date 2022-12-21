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
    public class SeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext _context;
        public SeatRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Create(Seat entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Seats.Add(entity);
            _context.SaveChanges();
        }

        public Seat Read(Guid id)
        {
            var seat = _context.Seats.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (seat == null)
                throw new ArgumentException(nameof(id), $"Not found seat with id: {id}");
            return seat;
        }

        public void Update(Seat entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var seat = _context.Seats.AsNoTracking().FirstOrDefault(s => s.Id == id);
            if (seat == null)
                throw new ArgumentException(nameof(id), $"Not found seat with id: {id}");
            _context.Seats.Remove(seat);
            _context.SaveChanges();
        }

        public PagedList<Seat> GetPageList(int pageNumber)
        {
            var list = _context.Seats.Skip((pageNumber - 1) * 20).Take(20);
            return new PagedList<Seat>(list.ToList(), pageNumber, 20, _context.Seats.Count());
        }
    }
}
