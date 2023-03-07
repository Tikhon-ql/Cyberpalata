using Cyberpalata.Logic.Configuration;
using Cyberpalata.WebApi;
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

//builder.Services.AddCors(o => o.AddPolicy("AllowAnyOrigin",
//                     builder =>
//                     {
//                         builder.AllowAnyOrigin()
//                                 .AllowAnyMethod()
//                                 .AllowAnyHeader();
//                     }));
//builder.Services.AddCors();

builder.Services.AddScoped<ModelStateValidationFilter>();

builder.Services.AddSingleton<IDictionary<string, UserConnection>>(opts => new Dictionary<string, UserConnection>());

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

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//app.UseCors(x =>
//{
//    x.AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//});


app.UseHttpLogging();

app.UseCors();

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.UseAuthorization();


app.Run();