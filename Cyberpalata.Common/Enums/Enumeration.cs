using System.ComponentModel.DataAnnotations;

namespace Cyberpalata.Common.Enums
{
    public class Enumeration : IComparable
    {

        public Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; private set; }
        public int CompareTo(object? obj) => Id.CompareTo(((Enumeration)obj).Id);
    }
}
