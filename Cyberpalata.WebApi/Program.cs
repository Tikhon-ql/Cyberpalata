using Cyberpalata.Logic.BackgroundWorkers;
using Cyberpalata.Logic.Configuration;
using Cyberpalata.WebApi;
using Cyberpalata.WebApi.Connections;
using Cyberpalata.WebApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new ModelStateValidationFilter());
}).AddNewtonsoftJson();

builder.Services.AddScoped<ModelStateValidationFilter>();

builder.Services.AddSingleton<IDictionary<string, ChatConnection>>(opts => new Dictionary<string, ChatConnection>());

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddLogging(logginBuilder =>
{
    logginBuilder.AddConsole().AddFilter(DbLoggerCategory.Database.Command.Name, Microsoft.Extensions.Logging.LogLevel.Information);
    logginBuilder.AddDebug();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
        builder.SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"]))
    };
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureLogicLayer(builder.Configuration);

builder.Services.AddHostedService<TournamentBackgroundWorker>();
builder.Services.AddHostedService<ChatDeleteingBackgroundWorker>();


builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseHttpLogging();

app.UseCors();

app.MapControllers();

app.MapHub<ChatHub>("/chat");
app.MapHub<NotificationHub>("/notify");

app.UseAuthorization();


app.Run();