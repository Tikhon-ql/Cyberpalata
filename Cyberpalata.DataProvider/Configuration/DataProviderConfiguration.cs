using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.Context;
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
            var connectionString = configuration.GetConnectionString("CyberpalataConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString).UseLazyLoadingProxies();
                options.EnableSensitiveDataLogging();
            });

         
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IApiUserRepository, ApiUserRepository>();
            services.AddScoped<IGameConsoleRepository, GameConsoleRepository>();
            services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
            services.AddScoped<IPcRepository, PcRepository>();
            services.AddScoped<IPeripheryRepository, PeripheryRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();
        }
    }
}
