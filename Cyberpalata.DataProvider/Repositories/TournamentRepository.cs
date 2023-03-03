using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(ApplicationDbContext context) : base(context)
        {
        }
        public List<Tournament> GetAll()
        {
            return _context.Tournaments.ToList();
        }
    }
}
