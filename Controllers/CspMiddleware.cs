namespace Intex2Group22.Controllers
{

using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http.Headers;
using System.Threading.Tasks;

public class CspMiddleware
    {
        private readonly RequestDelegate _next;

        public CspMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self'; style-src 'self'; font-src 'self'; img-src 'self'; frame-src 'self'"); // Define CSP Policy here
            await _next(context);
        }
    }

}
