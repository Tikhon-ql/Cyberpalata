using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override Task<Guid> CreateAsync(Team entity)
        {
            foreach(var memeber in entity.Members)
                memeber.Id = Guid.NewGuid();    
            return base.CreateAsync(entity);
        }
    }
}
