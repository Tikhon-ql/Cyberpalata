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
        Task CreateAsync(T entity);
        Task<T> ReadAsync(Guid id);
        //void Update(T entity);
        Task DeleteAsync(Guid id);
        Task<PagedList<T>> GetPageListAsync(int pageNumber);
    }
}
