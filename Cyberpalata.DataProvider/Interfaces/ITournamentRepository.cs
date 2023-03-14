using Cyberpalata.DataProvider.Models.Tournaments;

namespace Cyberpalata.DataProvider.Interfaces
{
    public interface ITournamentRepository : IRepository<Tournament>, IDisposable
    {
        List<Tournament> GetAll();
    }
}
