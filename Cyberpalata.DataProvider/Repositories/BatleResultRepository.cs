using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class BatleResultRepository : BaseRepository<BatleResult>, IBatleResultRepository
    {
        public BatleResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
