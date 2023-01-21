using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cyberpalata.DataProvider.Configuration
{
    public static class DataProviderConfiguration
    {
        public static void ConfigureDataProvider(this IServiceCollection services, IConfiguration configuration)
        {
            //. options.UseSqlServer(connection, b => b.MigrationsAssembly("Cyberpalata.WebApi")). By default,
            //the migrations assembly is the assembly containing the DbContext.
            //Change your target project to the migrations project by using the Package Mana

                        var connectionString = configuration.GetConnectionString("CyberpalataConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

         
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApiUserRepository, ApiUserRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IApiUserRepository, ApiUserRepository>();
            services.AddTransient<IGameConsoleRepository, GameConsoleRepository>();
            services.AddTransient<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddTransient<IPcRepository, PcRepository>();
            services.AddTransient<IPeripheryRepository, PeripheryRepository>();
            //services.AddTransient<IGameConsoleRoomRepository, GameConsoleRoomRepository>();
            //services.AddTransient<ISeatRepository, SeatRepository>();
            //services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            //services.AddTransient<IGamingRoomRepository, GamingRoomRepository>();
            //services.AddTransient<ILoungeRepository, LoungeRepository>();
        }
    }
}
