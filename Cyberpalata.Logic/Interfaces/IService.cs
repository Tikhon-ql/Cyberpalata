using CSharpFunctionalExtensions;
using Cyberpalata.Common;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<Maybe<T>> ReadAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<T>> SearchAsync(Guid id);
        Task<PagedList<T>> GetPagedListAsync(int pageNumber);
    }
}
