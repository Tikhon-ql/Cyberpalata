using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        ISeatRepository SeatRepository { get; }
        IPriceRepository PriceRepository { get; }
        IRoomRepository RoomRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IPeripheryRepository PeripheryRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        IGameRepository GameRepository { get; }
        Task CommitAsync();
    }
}
