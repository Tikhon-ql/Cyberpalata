using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _context;
        public PriceRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(Price entity)
        {
            await _context.Prices.AddAsync(entity);
        }

        public async Task<Maybe<Price>> ReadAsync(Guid id)
        {
            var price = await _context.Prices.FirstOrDefaultAsync(p => p.Id == id);
            return price.ToMaybe();
        }


        public void Delete(Price price)
        {
            _context.Prices.Remove(price);
        }

        public async Task<PagedList<Price>> GetPageListAsync(int pageNumber)
        {
            var list = await _context.Prices.Skip((pageNumber - 1) * 10).Take(10).ToListAsync();
            return new PagedList<Price>(list, pageNumber, 10, _context.Prices.Count());
        }

        public async Task<Maybe<List<Price>>> GetByRoomIdAsync(Guid roomId)
        {
            var roomPrices = await _context.Prices.Where(p => p.Room.Id == roomId).ToListAsync();
            return roomPrices.ToMaybe();
        }
    }
}