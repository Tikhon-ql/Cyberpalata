using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Repositories;

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
