using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Peripheral;
using Cyberpalata.DataProvider.Context;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class PeripheryRepository :BaseRepository<Periphery>, IPeripheryRepository
    {
        public PeripheryRepository(ApplicationDbContext context):base(context)
        {
        }
    }
}
