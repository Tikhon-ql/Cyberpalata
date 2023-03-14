using Cyberpalata.DataProvider.Configuration;
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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameConsoleService, GameConsoleService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IPcService, PcService>();
            services.AddScoped<IPeripheryService, PeripheryService>();
            services.AddScoped<IHashGenerator, HashGenerator>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IBatleResultService, BatleResultService>();
            services.AddScoped<IBatleService, BatleService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITeamJoinRequestService, TeamJoinRequestService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
