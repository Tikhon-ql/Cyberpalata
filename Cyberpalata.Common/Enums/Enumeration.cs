using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Common.Enums
{
    public class Enumeration : IComparable
    {

        public Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CompareTo(object? obj) => Id.CompareTo(((Enumeration)obj).Id);
    }
}
