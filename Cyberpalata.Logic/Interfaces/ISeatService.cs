using Cyberpalata.Logic.Models;

namespace Cyberpalata.Logic.Interfaces
{
    public interface ISeatService : IService<SeatDto>
    {
        Task CreateRangeAsync(List<SeatDto> seats);
    }
}
