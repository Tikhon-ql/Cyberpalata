﻿using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Context;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

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
            var price = await _context.Prices.SingleAsync(p => p.Id == id);
            return price;
        }


        public void Delete(Price price)
        {
            _context.Prices.Remove(price);
        }

        private PagedList<Maybe<Price>> GetPageList(int pageNumber)
        {
            var list = _context.Prices.Skip((pageNumber - 1) * 10).Take(10).Select(item=>(Maybe<Price>)item);
            return new PagedList<Maybe<Price>>(list.ToList(), pageNumber, 10, _context.Prices.Count());
        }

        public async Task<PagedList<Maybe<Price>>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }

        public async Task<List<Maybe<Price>>> GetByRoomIdAsync(Guid roomId)
        {
            return await _context.Prices.Where(p => p.Room.Id == roomId).Select(item=>(Maybe<Price>)item).ToListAsync();
        }
    }
}