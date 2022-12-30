using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Repositories;
using Microsoft.AspNetCore.Identity;
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
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApiUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPcRepository, PcRepository>();
            services.AddTransient<IPeripheryRepository, PeripheryRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IApiUserRepository, ApiUserRepository>();
            //services.AddTransient<ISeatRepository, SeatRepository>();
            //services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            //services.AddTransient<IGameConsoleRepository, GameConsoleRepository>();
            //services.AddTransient<IGameConsoleRoomRepository, GameConsoleRoomRepository>();
            //services.AddTransient<IGamingRoomRepository, GamingRoomRepository>();
            //services.AddTransient<ILoungeRepository, LoungeRepository>();
            
        }
    }
}
