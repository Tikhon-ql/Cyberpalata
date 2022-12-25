using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cyberpalata.DataProvider.Configuration
{
    public static class DataProviderConfiguration
    {
        public static void ConfigureDataProvider(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionStirng = configuration.GetConnectionString("CyberpalataConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionStirng);
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IPeripheryRepository, PeripheryRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
        }
    }
}
