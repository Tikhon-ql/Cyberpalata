using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.DataProvider.Configuration;
using Cyberpalata.Logic.Interfaces;
using Cyberpalata.Logic.Interfaces.Room;
using Cyberpalata.Logic.Services;
using Cyberpalata.Logic.Services.Room;
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

            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPcService, PcService>();
            services.AddTransient<IPeripheryService, PeripheryService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IApiUserService, ApiUserService>();
            services.AddTransient<IGameConsoleService, GameConsoleService>();
            services.AddTransient<IGameConsoleRoomService, GameConsoleRoomService>();
            services.AddTransient<IGamingRoomService, GamingRoomService>();
            //services.AddTransient<ISeatService, SeatService>();
            //services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}
