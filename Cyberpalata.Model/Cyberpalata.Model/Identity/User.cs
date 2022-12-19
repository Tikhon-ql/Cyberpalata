using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Model.Identity
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        // booking and all visits
    }
}
