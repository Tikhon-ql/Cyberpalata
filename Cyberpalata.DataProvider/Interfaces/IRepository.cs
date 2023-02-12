using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.Common.Filters;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<Guid> CreateAsync(T entity);
        Task<Maybe<T>> ReadAsync(Guid id);
        void Delete(T entity);
        Task<PagedList<T>> GetPageListAsync(BaseFilter filter);
    }
}
