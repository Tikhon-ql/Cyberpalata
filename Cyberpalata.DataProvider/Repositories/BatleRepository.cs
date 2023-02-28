using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BatleRepository : BaseRepository<Batle>, IBatleRepository
    {
        public BatleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
