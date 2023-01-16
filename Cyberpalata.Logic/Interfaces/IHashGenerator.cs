using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IHashGenerator
    {
        string HashPassword(string password);
        string GenerateSalt();
    }
}
