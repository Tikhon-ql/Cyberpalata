using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Interfaces.UnitOfWork;
using Cyberpalata.DataProvider.Repositories;

namespace Cyberpalata.DataProvider
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            SeatRepository = new SeatRepository(context);
            PriceRepository = new PriceRepository(context);
            RoomRepository = new RoomRepository(context);
            DeviceRepository = new DeviceRepository(context);
            PeripheryRepository = new PeripheryRepository(context);
            MenuItemRepository = new MenuItemRepository(context);
            PriceRepository = new PriceRepository(context);
            GameRepository = new GameRepository(context);
        }

        public ISeatRepository SeatRepository { get; }
        public IPriceRepository PriceRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public IDeviceRepository DeviceRepository { get;  }
        public IPeripheryRepository PeripheryRepository { get; }
        public IMenuItemRepository MenuItemRepository { get; }
        public IGameRepository GameRepository { get; }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
