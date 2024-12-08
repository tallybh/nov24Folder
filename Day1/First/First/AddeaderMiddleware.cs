using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace First
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AddeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.Add("MyHeader", "new");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AddeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseAddeaderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddeaderMiddleware>();
        }
    }
}
