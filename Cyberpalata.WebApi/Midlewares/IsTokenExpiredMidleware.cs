using Cyberpalata.Logic.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace Cyberpalata.WebApi.Midlewares
{
    public class IsTokenExpiredMidleware
    {
        private readonly RequestDelegate _next;
        //private readonly IUserRefreshTokenService _userRefreshTokenService;

        public IsTokenExpiredMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.GetTokenAsync("accessToken");
            context.Request.Headers.ToList().ForEach(item => Console.WriteLine(item.Value)); ;
            await _next.Invoke(context);
        }
    }
}
