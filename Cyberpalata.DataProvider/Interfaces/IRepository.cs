using Cyberpalata.Common;
using Functional.Maybe;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<Maybe<T>> ReadAsync(Guid id);
        void Delete(T entity);
        Task<PagedList<T>> GetPageListAsync(int pageNumber);
    }
}
