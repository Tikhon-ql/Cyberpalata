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
    //internal class SeatRepository : ISeatRepository
    //{
    //    private readonly ApplicationDbContext _context;
    //    public SeatRepository(ApplicationDbContext context)
    //    {
    //        this._context = context;
    //    }
    //    public async Task CreateAsync(Seat entity)
    //    {
    //        if (entity == null)
    //            throw new ArgumentNullException(nameof(entity));
    //        await _context.Seats.AddAsync(entity);
    //    }

    //    public async Task<Seat> ReadAsync(Guid id)
    //    {
    //        var seat = await _context.Seats.SingleAsync(s => s.Id == id);
    //        return seat;
    //    }

    //    public async Task DeleteAsync(Guid id)
    //    {
    //        var seat = await _context.Seats.SingleAsync(s => s.Id == id);
    //        _context.Seats.Remove(seat);
    //    }

    //    private PagedList<Seat> GetPageList(int pageNumber)
    //    {
    //        var list = _context.Seats.Skip((pageNumber - 1) * 20).Take(20);
    //        return new PagedList<Seat>(list.ToList(), pageNumber, 20, _context.Seats.Count());
    //    }

    //    public async Task<PagedList<Seat>> GetPageListAsync(int pageNumber)
    //    {
    //        return await Task.Run(() => GetPageList(pageNumber));
    //    }
    //}
}
