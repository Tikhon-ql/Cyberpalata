using Cyberpalata.DataProvider.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cyberpalata.Logic.Configuration
{
    public static class LogicConfiguration
    {
        public static void ConfigureLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataProvider(configuration);

            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IApiUserService, ApiUserService>();
            services.AddTransient<IGameConsoleService, GameConsoleService>();
            services.AddTransient<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPcService, PcService>();
            services.AddTransient<IPeripheryService, PeripheryService>();
            services.AddTransient<IHashGenerator,HashGenerator>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<ISeatService, SeatService>();
            //services.AddScoped<ILoggerManager, LoggerManager>();
            //services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}
