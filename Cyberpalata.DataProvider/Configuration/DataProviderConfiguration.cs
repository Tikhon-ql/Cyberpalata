using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Context;
using Cyberpalata.DataProvider.Context.Triggers;
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
                options.EnableSensitiveDataLogging();
            });

         
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<IGameConsoleRepository, GameConsoleRepository>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddScoped<IPcRepository, PcRepository>();
            services.AddScoped<IPeripheryRepository, PeripheryRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            //services.AddTransient<IGameConsoleRoomRepository, GameConsoleRoomRepository>();
            //services.AddTransient<ISeatRepository, SeatRepository>();
            //services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            //services.AddTransient<IGamingRoomRepository, GamingRoomRepository>();
            //services.AddTransient<ILoungeRepository, LoungeRepository>();
        }
    }
}
