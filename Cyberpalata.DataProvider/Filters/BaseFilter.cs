using Cyberpalata.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Filters
{
    public class BaseFilter<T> where T : BaseEntity
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public virtual IQueryable<T> EnrichQuery(IQueryable<T> query) { return query; }
    }   
}
