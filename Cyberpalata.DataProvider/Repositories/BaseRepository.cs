using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Filters;
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
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }
        public virtual async Task<Guid> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            await _context.AddAsync(entity);
            return entity.Id;
        }   

        public virtual void Delete(T entity) => _context.Remove(entity);
        public virtual async Task<PagedList<T>> GetPageListAsync(BaseFilter<T> filter)
        {
            IQueryable<T> list = _entitySet.AsQueryable<T>();
            list = filter.EnrichQuery(list);
            list = list.Skip(((filter.CurrentPage - 1) * filter.PageSize)).Take(filter.PageSize);
            return new PagedList<T>(list.ToList(), filter.CurrentPage, filter.PageSize, _entitySet.Count());
        }

        public virtual async Task<Maybe<T>> ReadAsync(Guid id) => await _entitySet.FirstOrDefaultAsync(e=>e.Id == id);
    }
}
