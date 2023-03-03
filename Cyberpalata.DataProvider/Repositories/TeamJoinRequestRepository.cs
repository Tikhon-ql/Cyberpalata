using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class TeamJoinRequestRepository : BaseRepository<TeamJoinRequest>, ITeamJoinRequestRepository
    {
        public TeamJoinRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
