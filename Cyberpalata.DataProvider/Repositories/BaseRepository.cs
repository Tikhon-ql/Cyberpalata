using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BaseRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
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

        public void Dispose()
        {
            _context.Dispose();
        }

        public virtual async Task<PagedList<T>> GetPageListAsync(BaseFilter<T> filter)
        {
            IQueryable<T> list = _entitySet.AsQueryable<T>();
            list = filter.EnrichQuery(list);
            int totalItemsCount = list.Count();
            int currentPage = filter.CurrentPage;
            if (totalItemsCount > filter.PageSize)
                list = list.Skip(((filter.CurrentPage - 1) * filter.PageSize)).Take(filter.PageSize);
            else
                currentPage = 1;
            return new PagedList<T>(list.ToList(), currentPage, filter.PageSize, totalItemsCount);
        }

        public virtual async Task<Maybe<T>> ReadAsync(Guid id) => await _entitySet.FirstOrDefaultAsync(e=>e.Id == id);
    }
}
