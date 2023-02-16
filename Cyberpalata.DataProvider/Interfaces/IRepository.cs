using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Filters;
using Cyberpalata.DataProvider.Models;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRepository<T> where T : BaseEntity 
    {
        Task<Guid> CreateAsync(T entity);
        Task<Maybe<T>> ReadAsync(Guid id);
        void Delete(T entity);
        Task<PagedList<T>> GetPageListAsync(BaseFilter<T> filter);
    }
}
