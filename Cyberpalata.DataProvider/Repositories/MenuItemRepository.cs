using Cyberpalata.DataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.DbContext;
using Microsoft.EntityFrameworkCore;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(MenuItem entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await _context.MenuItems.AddAsync(entity);
        }

        public async Task<MenuItem> ReadAsync(Guid id)
        {
            var position = await _context.MenuItems.SingleAsync(p => p.Id == id);
            return position;
        }


        public async Task DeleteAsync(Guid id)
        {
            var position = await _context.MenuItems.SingleAsync(p => p.Id == id);
            _context.MenuItems.Remove(position);
        }

        private PagedList<MenuItem> GetPageList(int pageNumber)
        {
            var list = _context.MenuItems.Skip((pageNumber - 1) * 20).Take(20);
            return new PagedList<MenuItem>(list.ToList(), pageNumber, 20, _context.MenuItems.Count());
        }

        public async Task<PagedList<MenuItem>> GetPageListAsync(int pageNumber)
        {
            return await Task.Run(() => GetPageList(pageNumber));
        }
    }
}
