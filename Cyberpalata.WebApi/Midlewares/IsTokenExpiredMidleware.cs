using Cyberpalata.Logic.Interfaces;

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
            _next.Invoke(context);
            var service = context.RequestServices.GetService<IUserRefreshTokenService>();
            if (context.Response.Headers["IS-TOKEN-EXPIRED"] == "true")
            {
                context.Response.Headers.Add("Result", "GOOD");
            }
        }
    }
}
