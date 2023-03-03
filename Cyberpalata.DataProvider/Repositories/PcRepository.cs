using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PcRepository :BaseRepository<Pc>, IPcRepository
    {
        public PcRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
