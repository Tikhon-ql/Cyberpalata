using Cyberpalata.Common;
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
        Task<Maybe<T>> ReadAsync(Guid id);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<T>> SearchAsync(Guid id);
        Task<PagedList<Maybe<T>>> GetPagedListAsync(int pageNumber);
    }
}
