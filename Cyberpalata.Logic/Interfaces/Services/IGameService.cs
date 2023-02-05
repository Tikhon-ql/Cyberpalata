using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces.Services
{
    public interface IGameService : IService<GameDto>
    {
        Task CreateRange(List<GameDto> games);
    }
}
