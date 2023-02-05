using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces.Filters
{
    public interface IFilter<T>
    {
        bool IsValid(T obj);
    }
}
