using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class TeamMemberRepository : BaseRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
