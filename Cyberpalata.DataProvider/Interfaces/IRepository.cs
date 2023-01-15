using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<Result> CreateAsync(T entity);
        Task<T> ReadAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<PagedList<T>> GetPageListAsync(int pageNumber);
    }
}
