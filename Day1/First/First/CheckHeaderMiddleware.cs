using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace First
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Headers.ContainsKey("MyHeader"))
            {
                await _next(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 401;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckHeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckHeaderMiddleware>();
        }
    }
}
