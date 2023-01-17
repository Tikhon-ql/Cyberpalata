using Cyberpalata.Common;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> ReadAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<T>> SearchAsync(Guid id);
        Task<PagedList<T>> GetPagedListAsync(int pageNumber);
    }
}
