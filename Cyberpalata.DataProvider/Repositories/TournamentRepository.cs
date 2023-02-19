using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Guid> CreateAsync(Tournament entity)
        {
            foreach (var round in entity.Rounds)
                round.Id = Guid.NewGuid();
            return base.CreateAsync(entity);
        }
        public List<Tournament> GetAll()
        {
            return _context.Tournaments.ToList();
        }
    }
}
