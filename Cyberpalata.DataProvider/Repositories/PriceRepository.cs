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
    //internal class PriceRepository : IPriceRepository
    //{
    //    private readonly ApplicationDbContext _context;
    //    public PriceRepository(ApplicationDbContext context)
    //    {
    //        this._context = context;
    //    }
    //    public async Task CreateAsync(Price entity)
    //    {
    //        if (entity == null)
    //            throw new ArgumentNullException(nameof(entity));
    //        await _context.Prices.AddAsync(entity);
    //    }

    //    public async Task<Price> ReadAsync(Guid id)
    //    {
    //        var price = await _context.Prices.SingleAsync(p => p.Id == id);
    //        return price;
    //    }


    //    public async Task DeleteAsync(Guid id)
    //    {
    //        var price = await _context.Prices.SingleAsync(p => p.Id == id);
    //        _context.Prices.Remove(price);
    //    }

    //    private PagedList<Price> GetPageList(int pageNumber)
    //    {
    //        var list = _context.Prices.Skip((pageNumber - 1) * 10).Take(10);
    //        return new PagedList<Price>(list.ToList(), pageNumber, 10, _context.Prices.Count());
    //    }

    //    public async Task<PagedList<Price>> GetPageListAsync(int pageNumber)
    //    {
    //        return await Task.Run(() => GetPageList(pageNumber));
    //    }
    //}
}