﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPcService, PcService>();
            services.AddTransient<IPeripheryService, PeripheryService>();
            services.AddTransient<IPriceService, PriceService>();
            //services.AddTransient<ISeatService, SeatService>();
            //services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}