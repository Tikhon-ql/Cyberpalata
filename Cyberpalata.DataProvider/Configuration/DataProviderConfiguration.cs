using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberpalata.Common.Intefaces;
using Cyberpalata.DataProvider.DbContext;
using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Interfaces.Room;
using Cyberpalata.DataProvider.Models.Identity;
using Cyberpalata.DataProvider.Repositories;
using Cyberpalata.DataProvider.Repositories.Room;
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

            services.AddIdentity<ApiUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IPcRepository, PcRepository>();
            services.AddTransient<IPeripheryRepository, PeripheryRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IApiUserRepository, ApiUserRepository>();
            services.AddTransient<IGameConsoleRepository, GameConsoleRepository>();
            services.AddTransient<IGameConsoleRoomRepository, GameConsoleRoomRepository>();
            //services.AddTransient<ISeatRepository, SeatRepository>();
            //services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            //services.AddTransient<IGamingRoomRepository, GamingRoomRepository>();
            //services.AddTransient<ILoungeRepository, LoungeRepository>();
        }
    }
}
