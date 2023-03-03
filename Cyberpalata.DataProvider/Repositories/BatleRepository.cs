using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BatleRepository : BaseRepository<Batle>, IBatleRepository
    {
        public BatleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
