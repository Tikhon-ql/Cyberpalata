using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entitySet;
        protected readonly IConfiguration _configuration;
        public BaseRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _entitySet = _context.Set<T>();
            _configuration = configuration;
        }
        public async Task CreateAsync(T entity) => await _context.AddAsync(entity);

        public void Delete(T entity) => _context.Remove(entity);
        public virtual async Task<PagedList<T>> GetPageListAsync(int pageNumber)
        {
            var list = await _entitySet.Skip(((pageNumber - 1) * int.Parse(_configuration["PaginationSettings:defaultPageSize"]))).Take(int.Parse(_configuration["PaginationSettings:defaultPageSize"])).ToListAsync();
            return new PagedList<T>(list, pageNumber, int.Parse(_configuration["PaginationSettings:defaultPageSize"]), _entitySet.Count());
        }

        public async Task<Maybe<T>> ReadAsync(Guid id) => await _entitySet.FirstOrDefaultAsync(e=>e.Id == id);
    }
}
