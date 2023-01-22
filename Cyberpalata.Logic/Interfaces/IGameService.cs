using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces
{
    public interface IGameService : IService<GameDto>
    {
        Task CreateRange(List<GameDto> games);
    }
}
