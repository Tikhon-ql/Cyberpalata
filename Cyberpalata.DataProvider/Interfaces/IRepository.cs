using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Support;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T Read(Guid id);
        void Update(T entity);
        void Delete(Guid id);
        PagedList<T> GetPageList(int pageNumber);
    }
}
