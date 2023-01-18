using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Context;

namespace Cyberpalata.DataProvider
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
