using CSharpFunctionalExtensions;
using Cyberpalata.DataProvider.Models.Devices;

namespace Cyberpalata.DataProvider.Interfaces
{
    //A.K.: Empty interface is not needed. Less code, less bugs
    public interface IGameConsoleRepository : IRepository<GameConsole>
    {
    }
}
