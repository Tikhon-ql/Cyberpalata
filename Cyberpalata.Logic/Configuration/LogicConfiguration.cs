using Cyberpalata.DataProvider.Configuration;
using Cyberpalata.Logic.Filters;
using Cyberpalata.Logic.Interfaces.Filters;
using Cyberpalata.Logic.Interfaces.Services;
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

            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections= true;
                cfg.AllowNullDestinationValues= true;
            },typeof(AppMappingProfile));

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IApiUserService, ApiUserService>();
            services.AddScoped<IGameConsoleService, GameConsoleService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPcService, PcService>();
            services.AddScoped<IPeripheryService, PeripheryService>();
            services.AddScoped<IHashGenerator,HashGenerator>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IMailService, MailService>();
            services.AddSingleton<IBookingFilter, BookingFilter>();
            //services.AddScoped<ILoggerManager, LoggerManager>();
            //services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}
